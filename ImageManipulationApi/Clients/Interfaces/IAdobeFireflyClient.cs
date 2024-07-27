using ImageManipulationApi.Models;

namespace ImageManipulationApi.Clients.Interfaces
{
    public interface IAdobeFireflyClient
    {
        /// <summary>
        /// Get Access Token from Adobe Firefly Service
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        Task<string?> GetAccessTokenAsync(string clientId, string secret);

        /// <summary>
        /// Expand Image using Adobe Firefly Service
        /// </summary>
        /// <param name="expandImageRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<string?> ExpandImageAsync(ExpandImageRequest expandImageRequest, string? accessToken);

        /// <summary>
        /// Remove Background using Adobe Firefly Service
        /// </summary>
        /// <param name="removeBackgroundRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<string?> RemoveBackgroundJobAsync(RemoveBackgroundRequest removeBackgroundRequest, string? accessToken);

        /// <summary>
        /// Depth Blur using Adobe Firefly Service
        /// </summary>
        /// <param name="applyFilterRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<string?> DepthBlurAsync(DepthBlurRequest applyFilterRequest, string? accessToken);
    }
}
