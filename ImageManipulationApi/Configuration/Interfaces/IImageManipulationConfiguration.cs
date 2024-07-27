namespace Auctane.Monetization.Client.Configuration.Interfaces
{
    public interface IImageManipulationConfiguration
    {
        string AdobeFireflyTokenUrl { get; }
        string AdobeFireflyUrl { get; }

        string AdobeBaseUrl { get; }
        string ClientId { get; }
        string Secret { get; }
        string S3BucketName { get; }
        string S3Region { get; }

    }
}
