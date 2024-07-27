namespace ImageManipulationApi.Services.Interfaces
{
    public interface IS3Service
    {
        Task<string> UploadFileToS3Async(string fileName);
    }
}
