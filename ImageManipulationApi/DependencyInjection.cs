using Amazon.S3;
using Auctane.Monetization.Client.Configuration;
using Auctane.Monetization.Client.Configuration.Interfaces;
using ImageManipulationApi.Clients;
using ImageManipulationApi.Clients.Interfaces;
using ImageManipulationApi.Services;
using ImageManipulationApi.Services.Interfaces;

namespace ImageManipulationApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterImageManipulationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddAWSService<IAmazonS3>();
            services.AddSingleton<IImageManipulationConfiguration, ImageManipulationConfiguration>();
            services.AddSingleton<IImageManipulationService, ImageManipulationService>();
            services.AddSingleton<IAdobeFireflyClient, AdobeFireflyClient>();
            services.AddSingleton<IS3Client, S3Client>();
            services.AddSingleton<IS3Service, S3Service>();
            services.AddCors(options =>
            {
                options.AddPolicy("S3",
                    builder => { builder.SetIsOriginAllowed(origin => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials(); });
            }
);
            return services;
        }
    }
}
