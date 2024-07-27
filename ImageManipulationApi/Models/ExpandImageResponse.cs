using Newtonsoft.Json;

namespace ImageManipulationApi.Models
{
    public class ExpandImageResponse
    {
        [JsonProperty("size")]
        public Size size { get; set; }

        [JsonProperty("outputs")]
        public List<Output> Outputs { get; set; }
    }

    public class  Output
    {
        [JsonProperty("seed")]
        public int Seed { get; set; }
        [JsonProperty("image")]
        public ResponseImage Image { get; set; }

    }

    public class ResponseImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
