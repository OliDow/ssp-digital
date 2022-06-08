using HotChocolate.Data;
using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Projections.Meter;

namespace Ssp.Digital.Meter.Api.Schema.Queries;

[ExtendObjectType(typeof(Query))]
public class MeterQueries
{
    /// <summary>
    /// Gets the meter asynchronous. multiple records.
    /// </summary>
    /// <param name="meterRepository">The meter repository.</param>
    /// <returns>meterRepository.</returns>
    [UseFiltering]
    public Task<IEnumerable<MeterProjection>> GetMeterAsync(
        [Service] IMeterRepository meterRepository) =>
       meterRepository.GetAllAsync();

    /// <summary>
    /// Gets the meter asynchronous. Singular record.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="meterRepository">The meter repository.</param>
    /// <returns>meterRepository.</returns>
    public Task<MeterProjection> GetMeterAsync(string id, [Service] IMeterRepository meterRepository) =>
        meterRepository.GetByIdAsync(id);
}