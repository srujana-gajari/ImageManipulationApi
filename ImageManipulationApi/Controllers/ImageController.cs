using ImageManipulationApi.Models;
using ImageManipulationApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImageManipulationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageManipulationService _imageManipulationService;
        public ImageController(IImageManipulationService imageManipulationService) {
            _imageManipulationService = imageManipulationService;
        }

        /// <summary>
        /// Get Access Token from Adobe Firefly Service
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("access-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(string clientId, string secret)
        {
            var result = await _imageManipulationService.GetAccessTokenAsync(clientId, secret);
            return Ok(result);
        }
        /// <summary>
        /// Expand Image using Adobe Firefly Service
        /// </summary>
        /// <param name="expandImageRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("expand")]
        [ProducesResponseType(typeof(ExpandImageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ExpandImageRequest expandImageRequest)
        {
            var result = await _imageManipulationService.ExpandImageAsync(expandImageRequest);
            return Ok(result);
        }
        /// <summary>
        /// Remove Background using Adobe Firefly Service
        /// </summary>
        /// <param name="removeBackgroundRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("remove-background")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RemoveBackgroundRequest removeBackgroundRequest)
        {
            var result = await _imageManipulationService.RemoveBackgroundJobAsync(removeBackgroundRequest);
            return Ok(result);
        }
        /// <summary>
        /// Depth Blur using Adobe Firefly Service
        /// </summary>
        /// <param name="applyFilterRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("depth-blur")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] DepthBlurRequest applyFilterRequest)
        {
            var result = await _imageManipulationService.DepthBlurAsync(applyFilterRequest);
            return Ok(result);
        }
    }
}
