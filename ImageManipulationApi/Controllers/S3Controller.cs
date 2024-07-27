using ImageManipulationApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImageManipulationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3Controller : ControllerBase
    {
        private readonly IS3Service _s3Service;
        public S3Controller(IS3Service s3Service)
        {
            _s3Service = s3Service;
        }

        /// <summary>
        /// Upload file to S3
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(string fileName)
        {
            var result = await _s3Service.UploadFileToS3Async(fileName);
            return Ok(result);
        }
    }
}
