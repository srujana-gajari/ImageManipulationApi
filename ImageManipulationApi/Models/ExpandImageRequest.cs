using Newtonsoft.Json;

namespace ImageManipulationApi.Models
{
    public class ExpandImageRequest
    {
        [JsonProperty("image")]
        public Image? Image { get; set; }
        [JsonProperty("size")]
        public Size? Size { get; set; }
    }
    public class Image
    {
        [JsonProperty("source")]
        public Source? Source { get; set; }
    }
    public class Source
    {
        [JsonProperty("url")]
        public string? Url { get; set; }
    }
    public class Size
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
