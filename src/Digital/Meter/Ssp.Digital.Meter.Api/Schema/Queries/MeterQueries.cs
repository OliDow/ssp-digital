using Ssp.Digital.Meter.Api.Schema.Queries;
using Ssp.Digital.Meter.Core.Repositories;

namespace Ssp.Digital.Meter.API.Queries;

[ExtendObjectType(typeof(Query))]
public class MeterQueries
{
    /// <summary>
    /// Gets the meter asynchronous. multiple records.
    /// </summary>
    /// <param name="meterRepository">The meter repository.</param>
    /// <returns>meterRepository.</returns>
    public Task<IEnumerable<Core.Entities.Meter>> GetMeterAsync(
        [Service] IMeterRepository meterRepository) =>
       meterRepository.GetAllAsync();

    /// <summary>
    /// Gets the meter asynchronous. Singular record.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="meterRepository">The meter repository.</param>
    /// <returns>meterRepository.</returns>
    public Task<Core.Entities.Meter> GetMeterAsync(string id, [Service] IMeterRepository meterRepository) =>
        meterRepository.GetByIdAsync(id);
}