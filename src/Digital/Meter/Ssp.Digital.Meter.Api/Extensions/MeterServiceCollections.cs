using Ssp.Common.Data.Repository;
using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Meter.Infrastructure.Data;
using Ssp.Digital.Meter.Infrastructure.Repositories;

namespace Ssp.Digital.Meter.Api.Extensions;

public static class MeterServiceCollections
{
    public static void AddMeterServiceCollections(this IServiceCollection services)
    {
        services.AddSingleton<IMeterProjectionsContext, MeterProjectionsContext>();
        services.AddScoped(typeof(IReadModelRepository<>), typeof(ReadModelRepository<>));
        services.AddScoped<IMeterRepository, MeterRepository>();
    }
}