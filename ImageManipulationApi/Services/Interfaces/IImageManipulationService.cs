using ImageManipulationApi.Models;

namespace ImageManipulationApi.Services.Interfaces
{
    public interface IImageManipulationService
    {
        Task<string> GetAccessTokenAsync(string clientId, string secret);
        Task<string?> ExpandImageAsync(ExpandImageRequest expandImageRequest);
        Task<AdobeStatusResponse?> RemoveBackgroundJobAsync(RemoveBackgroundRequest removeBackgroundRequest);
        Task<AdobeStatusResponse?> DepthBlurAsync(DepthBlurRequest applyFilterRequest);
    }
}
