using Ssp.Common.Cors;

namespace Ssp.Digital.Meter.Api.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCorsExtension(this IServiceCollection services)
        {
            services
                .AddCors(options =>
            options.AddPolicy(CorsPolicy.AllowAll, c => c
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()))
            ;
            return services;
        }
    }
}