using ImageManipulationApi.Models;

namespace ImageManipulationApi.Services.Interfaces
{
    public interface IImageManipulationService
    {
        Task<string> GetAccessTokenAsync(string clientId, string secret);
        Task<string?> ExpandImageAsync(ExpandImageRequest expandImageRequest);
        Task<string?> RemoveBackgroundJobAsync(RemoveBackgroundRequest removeBackgroundRequest);
        Task<string?> DepthBlurAsync(DepthBlurRequest applyFilterRequest);
    }
}
