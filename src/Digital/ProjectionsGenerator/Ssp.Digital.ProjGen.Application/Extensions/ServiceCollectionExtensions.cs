using Microsoft.Extensions.DependencyInjection;
using Ssp.Common.Data.Projections;
using Ssp.Digital.ProjGen.Application.Generators;
using System.Diagnostics.CodeAnalysis;

namespace Ssp.Digital.ProjGen.Application.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static void AddGenerators(this IServiceCollection services)
    {
        services.AddTransient<IProjectionRepository, ProjectionRepository>();

        // todo Update to user Scrutor
        services.AddTransient<IProjectionGenerator, MeterProjectionGenerator>();
        services.AddTransient<IProjectionGenerator, OtherProjectionGenerator>();
    }
}