namespace Ssp.Digital.Meter.Api.Extensions;

public static class HealthCheckExtension
{
    public static IServiceCollection AddHealthCheckExtension(this IServiceCollection services)
    {
        services
             .AddHealthChecks()
         ;

        return services;
    }
}