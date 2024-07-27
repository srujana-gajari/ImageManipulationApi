using Newtonsoft.Json;

namespace ImageManipulationApi.Models
{
    public class RemoveBackgroundRequest
    {
        [JsonProperty("input")]
        public Input? Input { get; set; }
        [JsonProperty("output")]
        public RemoveBackgroundOutput? Output { get; set; }
    }
    public class Input
    {
        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("storage")]
        public string? Storage { get; set; }
    }

    public class RemoveBackgroundOutput
    {
        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("storage")]
        public string? Storage { get; set; }

        [JsonProperty("mask")]
        public Mask Mask { get; set; }
    }

    public class Mask
    {
        [JsonProperty("format")]
        public string? Format = "soft";

    }

}
