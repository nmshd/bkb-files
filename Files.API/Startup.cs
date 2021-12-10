using Enmeshed.BuildingBlocks.API.Extensions;
using Files.API.Extensions;
using Files.API.JsonConverters;
using Files.Application;
using Files.Application.Extensions;
using Files.Infrastructure.EventBus;
using Files.Infrastructure.Persistence.Database;
using Microsoft.ApplicationInsights.Extensibility;

namespace Files.API;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        _env = env;
        _configuration = configuration;
    }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.Configure<ApplicationOptions>(_configuration.GetSection("ApplicationOptions"));

        services.AddCustomAspNetCore(_configuration, _env, options =>
        {
            options.Authentication.Audience = "files";
            options.Authentication.Authority = _configuration.GetAuthorizationConfiguration().Authority;
            options.Authentication.ValidIssuer = _configuration.GetAuthorizationConfiguration().ValidIssuer;

            options.Cors.AllowedOrigins = _configuration.GetCorsConfiguration().AllowedOrigins;
            options.Cors.ExposedHeaders = _configuration.GetCorsConfiguration().ExposedHeaders;

            options.HealthChecks.SqlConnectionString = _configuration.GetSqlDatabaseConfiguration().ConnectionString;

            options.Json.Converters.Add(new FileIdJsonConverter());
        });

        services.AddCustomApplicationInsights();

        services.AddCustomFluentValidation(_ => { });

        services.AddDatabase(dbOptions => { dbOptions.DbConnectionString = _configuration.GetSqlDatabaseConfiguration().ConnectionString; });

        services.AddAzureStorageAccount(options =>
        {
            options.ConnectionString = _configuration.GetBlobStorageConfiguration().ConnectionString;
            options.ContainerName = "files";
        });

        services.AddEventBus(_configuration.GetEventBusConfiguration());

        services.AddApplication();

        return services.ToAutofacServiceProvider();
    }

    public void Configure(IApplicationBuilder app, TelemetryConfiguration telemetryConfiguration)
    {
        telemetryConfiguration.DisableTelemetry = !_configuration.GetApplicationInsightsConfiguration().Enabled;

        app.ConfigureMiddleware(_env);
    }
}