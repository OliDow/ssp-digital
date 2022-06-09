using HotChocolate.Data;
using Ssp.Digital.Meter.Core.Repositories;
using Ssp.Digital.Projections.Meter;

namespace Ssp.Digital.Meter.Api.Schema.Queries;

[ExtendObjectType(typeof(Query))]
public class MeterQueries
{
    /// <summary>
    /// Gets the meter asynchronous. multiple records with pagination.
    /// </summary>
    /// <param name="meterRepository">The meter repository.</param>
    /// <returns>meterRepository.</returns>
    [UsePaging]
    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IExecutable<MeterProjection> GetMeterPaged(
        [Service] IMeterRepository meterRepository) =>
       meterRepository.GetAllAsExecutable();

    /// <summary>
    /// Gets the meter asynchronous. multiple records with pagination.
    /// </summary>
    /// <param name="meterRepository">The meter repository.</param>
    /// <returns>meterRepository.</returns>
    [UseSorting]
    [UseFiltering]
    public IExecutable<MeterProjection> GetMeter(
        [Service] IMeterRepository meterRepository) =>
       meterRepository.GetAllAsExecutable();

    /// <summary>
    /// Gets the meter asynchronous. Singular record.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="meterRepository">The meter repository.</param>
    /// <returns>meterRepository.</returns>
    [UseFirstOrDefault]
    public IExecutable<MeterProjection> GetMeter(string id, [Service] IMeterRepository meterRepository) =>
        meterRepository.GetByIdAsExecutable(id);
}