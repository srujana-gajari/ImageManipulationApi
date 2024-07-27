using Newtonsoft.Json;

namespace ImageManipulationApi.Models
{
    public class ErrorResponse
    {
        /// <summary>
        ///     Gets or Sets ErrorReferenceId
        /// </summary>
        [JsonProperty("error_reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorReferenceId { get; set; }

        /// <summary>
        ///     Gets or Sets Errors
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        /// <summary>
        ///     Gets or Sets ErrorCode
        /// </summary>
        [JsonProperty("error_code", NullValueHandling = NullValueHandling.Include)]
        public string ErrorCode { get; set; }

        /// <summary>
        ///     Gets or Sets ErrorMessage
        /// </summary>
        [JsonProperty("error_message", NullValueHandling = NullValueHandling.Include)]
        public string ErrorMessage { get; set; }

    }
}
