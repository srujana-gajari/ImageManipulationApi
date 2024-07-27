using Auctane.Monetization.Client.Configuration.Interfaces;
using ImageManipulationApi.Clients.Interfaces;
using ImageManipulationApi.Models;
using ImageManipulationApi.Services.Interfaces;

namespace ImageManipulationApi.Services
{
    public class ImageManipulationService : IImageManipulationService
    {
        private readonly IAdobeFireflyClient _adobeFireflyClient;
        private readonly IImageManipulationConfiguration _imageManipulationConfiguration;
        public ImageManipulationService(IAdobeFireflyClient adobeFireflyClient, IImageManipulationConfiguration imageManipulationConfiguration)
        {
            _adobeFireflyClient = adobeFireflyClient;
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
            return await _adobeFireflyClient.GetAccessTokenAsync(clientId, secret);
        }

        /// <summary>
        /// Expand Image using Adobe Firefly Service
        /// </summary>
        /// <param name="expandImageRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<string?> ExpandImageAsync(ExpandImageRequest expandImageRequest)
        {
            var accessToken = await _adobeFireflyClient.GetAccessTokenAsync(_imageManipulationConfiguration.ClientId, _imageManipulationConfiguration.Secret);
            return await _adobeFireflyClient.ExpandImageAsync(expandImageRequest, accessToken);
        }

        /// <summary>
        /// Remove Background using Adobe Firefly Service
        /// </summary>
        /// <param name="removeBackgroundRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<AdobeStatusResponse?> RemoveBackgroundJobAsync(RemoveBackgroundRequest removeBackgroundRequest)
        {
            string accessToken = await _adobeFireflyClient.GetAccessTokenAsync(_imageManipulationConfiguration.ClientId, _imageManipulationConfiguration.Secret);
            return await _adobeFireflyClient.RemoveBackgroundJobAsync(removeBackgroundRequest, accessToken);
        }

        /// <summary>
        /// Depth Blur using Adobe Firefly Service
        /// </summary>
        /// <param name="applyFilterRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<AdobeStatusResponse?> DepthBlurAsync(DepthBlurRequest applyFilterRequest)
        {
            string accessToken = await _adobeFireflyClient.GetAccessTokenAsync(_imageManipulationConfiguration.ClientId, _imageManipulationConfiguration.Secret);
            return await _adobeFireflyClient.DepthBlurAsync(applyFilterRequest, accessToken);
        }

    }
}
