using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ssp.Common.ApplicationInsights;

namespace Ssp.Common.Extensions;

public static class ApplicationInsightsExtension
{
    public static void AddApplicationInsights(this IServiceCollection services, IConfiguration configurationn)
    {
        services.AddOptions<ApplicationInsightsSettings>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configurationn.GetSection("ApplicationInsightsConfiguration").Bind(settings);

                if (string.IsNullOrEmpty(settings.ConnectionString))
                {
                    services.AddApplicationInsightsTelemetry(settings.ConnectionString);
                }
            });
    }
}