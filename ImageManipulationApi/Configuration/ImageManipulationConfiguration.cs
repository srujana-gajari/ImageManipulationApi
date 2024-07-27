using Auctane.Monetization.Client.Configuration.Interfaces;
using static System.Net.WebRequestMethods;

namespace Auctane.Monetization.Client.Configuration
{
    public class ImageManipulationConfiguration : IImageManipulationConfiguration
    {
        public string AdobeFireflyTokenUrl => "https://ims-na1.adobelogin.com/ims/token/v3";
        public string AdobeFireflyUrl => "https://firefly-api.adobe.io/v3/images/expand";
        public string AdobeBaseUrl => "https://image.adobe.io/";

        public string ClientId => "c2e303e975b4411f8c6b04f3cfc47e23";
        public string Secret => "p8e-ndlKdIpt9ajGDsb3jud2-WClgZhf_DHH";
        public string S3BucketName => "myfirstsrgs3bucket";
        public string S3Region => "us-west-1";

    }
}
