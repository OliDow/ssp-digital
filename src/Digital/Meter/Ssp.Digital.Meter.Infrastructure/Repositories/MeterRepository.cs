using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Meter.Infrastructure.Data;

namespace Ssp.Digital.Meter.Infrastructure.Repositories;

public class MeterRepository : BaseRepository<Core.Entities.Meter>, IMeterRepository
{
    public MeterRepository(IMeterProjectionsContext meterProjectionsContext)
        : base(meterProjectionsContext) { }
}