using Amazon.S3;
using Amazon.S3.Model;
using Auctane.Monetization.Client.Configuration.Interfaces;
using ImageManipulationApi.Clients.Interfaces;
using System.Diagnostics;

namespace ImageManipulationApi.Clients
{
    public class S3Client : IS3Client
    {
        private readonly IAmazonS3 _amazonS3Client;
        private readonly IImageManipulationConfiguration _configuration;
        private readonly ILogger<S3Client> _logger;
        public S3Client(ILogger<S3Client> logger, IAmazonS3 amazonS3Client, IImageManipulationConfiguration imageManipulationConfiguration) {
            _amazonS3Client = amazonS3Client;
            _configuration = imageManipulationConfiguration;
            _logger = logger;
        }


        /// <summary>
        /// Upload file to S3
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> UploadFileToS3Async(string fileName)
        {
            var stopwatch = new Stopwatch();
            try
            {
                PutObjectRequest putObject = new PutObjectRequest
                {
                    BucketName = _configuration.S3BucketName,
                    Key = fileName,
                    FilePath = Path.Combine(Environment.CurrentDirectory, fileName),
                    CannedACL = S3CannedACL.PublicRead
                };
                PutObjectResponse putObjectResponse = await _amazonS3Client.PutObjectAsync(putObject);
                return $"https://{_configuration.S3BucketName}.s3.{_configuration.S3Region}.amazonaws.com/{fileName}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UploadFileToS3Async failed for fileName={0}, Exception ={1}", fileName, ex);
                return "";
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation("UploadFileToS3Async call completed.Duration={0}ms", stopwatch.ElapsedMilliseconds);
            }

        }

    }
}
