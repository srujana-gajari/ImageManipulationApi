using Newtonsoft.Json;

namespace ImageManipulationApi.Models
{
    public class StatusResponse
    {
        [JsonProperty("jobId")]
        public string JobId { get; set; }

        [JsonProperty("outputs")]
        public List<StatusOutput> Outputs { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class StatusOutput
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
