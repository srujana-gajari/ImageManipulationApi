namespace ImageManipulationApi.Clients.Interfaces
{
    public interface IS3Client
    {

        /// <summary>
        /// Upload file to S3
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<string> UploadFileToS3Async(string fileName);
    }
}
