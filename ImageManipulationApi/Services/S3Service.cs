using ImageManipulationApi.Clients.Interfaces;
using ImageManipulationApi.Services.Interfaces;

namespace ImageManipulationApi.Services
{
    public class S3Service : IS3Service
    {
        private readonly IS3Client _iS3Client;
        public S3Service(IS3Client iS3Client)
        {
            _iS3Client = iS3Client;
        }


        /// <summary>
        /// Upload file to S3
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> UploadFileToS3Async(string fileName)
        {
            return await _iS3Client.UploadFileToS3Async(fileName);
        }
    }
}
