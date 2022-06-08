using Ssp.Common.Data.Repository;
using Ssp.Digital.Projections.Meter;

namespace Ssp.Digital.Meter.Core.Repositories;

public interface IMeterRepository : IReadModelRepository<MeterProjection>
{
}