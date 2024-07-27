using ImageManipulationApi;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, builder) =>
                    {

                        builder.AddSystemsManager(configureSource =>
                        {
                            Console.WriteLine("Calling Environment.GetEnvironmentVariable");
                            //string environment = Environment.GetEnvironmentVariable("ParameterStoreEnvironment");
                            //Console.WriteLine("environment:" + environment);
                            //configureSource.Path = $"/{environment}/app/Image/";
                            configureSource.Path = $"/app/Image/";
                            configureSource.Optional = false;
                            // Reload configuration data every 5 minutes.
                            configureSource.ReloadAfter = TimeSpan.FromMinutes(5);
                        });
                    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterImageManipulationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("S3");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

