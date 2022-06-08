using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ssp.Common.Data.Mongo;
using Ssp.Common.Data.Providers;
using System.Diagnostics.CodeAnalysis;

namespace Ssp.Common.Data.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static void AddMongo(this IServiceCollection services, IConfiguration configurationn)
    {
        services.AddOptions<MongoSettings>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configurationn.GetSection("MongoDbConfiguration").Bind(settings);
            });
    }

    public static void AddCqrs(this IServiceCollection services)
    {
        services.AddTransient<ICommandProvider, CommandProvider>();
    }
}