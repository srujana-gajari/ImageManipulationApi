using Newtonsoft.Json;

namespace ImageManipulationApi.Models
{
    public class DepthBlurRequest
    {
        [JsonProperty("inputs")]
        public List<Input> Inputs { get; set; }
        [JsonProperty("outputs")]
        public List<DepthBlurOutput> Outputs { get; set; }

        [JsonProperty("options")]
        public Options Options { get; set; }
    }

    public class DepthBlurOutput
    {
        [JsonProperty("storage")]
        public string? Storage { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
       
        [JsonProperty("href")]
        public string? Href { get; set; }
    }

    public class Options
    {
        [JsonProperty("haze")]
        public int Haze { get; set; }
        [JsonProperty("blurStrength")]
        public int BlurStrength { get; set; }
        [JsonProperty("focalSelector")]
        public FocalSelector FocalSelector { get; set; }
    }
    public class FocalSelector
    {
        [JsonProperty("x")]
        public decimal X { get; set; }
        [JsonProperty("y")]
        public decimal Y { get; set; }
    }
    public class AdobeStatusResponse
    {
        [JsonProperty("_links")]
        public Link Link { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }
    }
    public class Link
    {
        [JsonProperty("self")]
        public Self Self { get; set; }
    }
    public class Self
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
