using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Meter.Infrastructure.Data;
using Ssp.Digital.Projections.Meter;

namespace Ssp.Digital.Meter.Infrastructure.Repositories;

public class MeterRepository : ReadModelRepository<MeterProjection>, IMeterRepository
{
    public MeterRepository(IMeterProjectionsContext meterProjectionsContext)
        : base(meterProjectionsContext) { }
}