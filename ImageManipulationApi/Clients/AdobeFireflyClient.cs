using Auctane.Monetization.Client.Configuration.Interfaces;
using ImageManipulationApi.Clients.Interfaces;
using ImageManipulationApi.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace ImageManipulationApi.Clients
{
    public class AdobeFireflyClient : IAdobeFireflyClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AdobeFireflyClient> _logger;
        private readonly IImageManipulationConfiguration _imageManipulationConfiguration;
        public AdobeFireflyClient(IHttpClientFactory httpClientFactory, ILogger<AdobeFireflyClient> logger, IImageManipulationConfiguration imageManipulationConfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _imageManipulationConfiguration = imageManipulationConfiguration;
        }
        /// <summary>
        /// Get Access Token from Adobe Firefly Service
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public async Task<string?> GetAccessTokenAsync(string clientId, string secret)
        {
            var stopwatch = new Stopwatch();
            try
            {
                _logger.LogInformation("Adobe Firefly Token Call started with Url={0}", _imageManipulationConfiguration.AdobeFireflyTokenUrl);

                var url = _imageManipulationConfiguration.AdobeFireflyTokenUrl + $"?client_id={clientId}&client_secret={secret}&grant_type=client_credentials&scope=openid,AdobeID,firefly_enterprise,firefly_api,ff_apis";

                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url){ };

                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.SendAsync(requestMessage);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Adobe Firefly Token call failed. Status: {0} Message: {1}", (int)response.StatusCode, responseBody);
                }

                var tokenResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(responseBody);

                return tokenResponse?.AccessToken;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Adobe Firefly Token call failed. Exception={0}", ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Adobe Firefly Token call completed. Duration={0}", stopwatch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Expand Image using Adobe Firefly Service
        /// </summary>
        /// <param name="expandImageRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<string?> ExpandImageAsync(ExpandImageRequest expandImageRequest, string? accessToken)
        {
            var stopwatch = new Stopwatch();
            try
            {
                _logger.LogInformation("Adobe Firefly BaseUrl Call started with Url={0}", _imageManipulationConfiguration.AdobeFireflyUrl);

                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, _imageManipulationConfiguration.AdobeFireflyUrl)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(expandImageRequest), Encoding.UTF8, "application/json")
                };
                requestMessage.Headers.Add("X-API-Key", _imageManipulationConfiguration.ClientId);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.SendAsync(requestMessage);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Adobe Firefly Service call failed. Status: {0} Message: {1}", (int)response.StatusCode, responseBody);
            
                }
                var imageExpandResponse = JsonConvert.DeserializeObject<ExpandImageResponse>(responseBody);

                return imageExpandResponse?.Outputs[0].Image?.Url;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Adobe Firefly Service call failed. Exception={0}", ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Adobe Firefly Service call completed. Duration={0}", stopwatch.ElapsedMilliseconds);
            }
      
        }
        /// <summary>
        /// Remove Background using Adobe Firefly Service
        /// </summary>
        /// <param name="removeBackgroundRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<AdobeStatusResponse?> RemoveBackgroundJobAsync(RemoveBackgroundRequest removeBackgroundRequest, string? accessToken)
        {
            var stopwatch = new Stopwatch();
            try
            {
                var url = _imageManipulationConfiguration.AdobeBaseUrl + "/sensei/cutout";
                _logger.LogInformation("RemoveBackgroundJobAsync Call started with Url={0}", url);

                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(removeBackgroundRequest), Encoding.UTF8, "application/json")
                };
                requestMessage.Headers.Add("X-API-Key", _imageManipulationConfiguration.ClientId);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.SendAsync(requestMessage);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("RemoveBackgroundJobAsync call failed. Status: {0} Message: {1}", (int)response.StatusCode, responseBody);
                    throw new Exception(responseBody);

                }
                var depthBlurResponse = JsonConvert.DeserializeObject<AdobeStatusResponse>(responseBody);
                await Task.Delay(5000);
                return await GetStatusAsync(depthBlurResponse, accessToken, "RB");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RemoveBackgroundJobAsync call failed. Exception={0}", ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("RemoveBackgroundJobAsync call completed. Duration={0}", stopwatch.ElapsedMilliseconds);
            }

        }
        /// <summary>
        /// Depth Blur using Adobe Firefly Service
        /// </summary>
        /// <param name="applyFilterRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<AdobeStatusResponse?> DepthBlurAsync(DepthBlurRequest applyFilterRequest, string? accessToken)
        {
            var stopwatch = new Stopwatch();
            try
            {
                var url = _imageManipulationConfiguration.AdobeBaseUrl + "/pie/psdService/depthBlur";
                _logger.LogInformation("DepthBlurAsync Call started with Url={0}", url);

                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(applyFilterRequest), Encoding.UTF8, "application/json")
                };
                requestMessage.Headers.Add("X-API-Key", _imageManipulationConfiguration.ClientId);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.SendAsync(requestMessage);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("DepthBlurAsync call failed. Status: {0} Message: {1}", (int)response.StatusCode, responseBody);
                    throw new Exception(responseBody);
                }
                var depthBlurResponse = JsonConvert.DeserializeObject<AdobeStatusResponse>(responseBody);
                await Task.Delay(5000);
                return await GetStatusAsync(depthBlurResponse, accessToken, "DB");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DepthBlurAsync call failed. Exception={0}", ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("DepthBlurAsync call completed. Duration={0}", stopwatch.ElapsedMilliseconds);
            }
        }
        /// <summary>
        /// Get Status from Adobe Firefly Service
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private async Task<AdobeStatusResponse> GetStatusAsync(AdobeStatusResponse adobeStatusResponse, string? accessToken, string flag)
        {
            var stopwatch = new Stopwatch();
            try
            {
                _logger.LogInformation("GetStatusAsync Call started with Url={0}", adobeStatusResponse.Link.Self.Href);

                using var requestMessage = new HttpRequestMessage(HttpMethod.Get, adobeStatusResponse.Link.Self.Href);

                requestMessage.Headers.Add("X-API-Key", _imageManipulationConfiguration.ClientId);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.SendAsync(requestMessage);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GetStatusAsync call failed. Status: {0} Message: {1}", (int)response.StatusCode, responseBody);
                    throw new Exception(responseBody);
                }
                if (flag == "DB")
                {
                    var statusResponse = JsonConvert.DeserializeObject<StatusResponse>(responseBody);
                    adobeStatusResponse.Link.Self.Status = statusResponse.Outputs[0].Status;
                    adobeStatusResponse.Input = statusResponse.Outputs[0].Input;
                    return adobeStatusResponse;
                }
                else if (flag == "RB")
                {
                    var statusResponse = JsonConvert.DeserializeObject<StatusResponse>(responseBody);
                    adobeStatusResponse.Link.Self.Status = statusResponse.Status;
                    adobeStatusResponse.Input = statusResponse.Input;
                    return adobeStatusResponse;
                }
                else
                    return new AdobeStatusResponse();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetStatusAsync call failed. Exception={0}", ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("GetStatusAsync call completed. Duration={0}", stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
