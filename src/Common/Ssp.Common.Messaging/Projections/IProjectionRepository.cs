namespace Ssp.Common.Messaging.Projections;

public interface IProjectionRepository
{
    Task<IReadOnlyCollection<IProjection>> GetProjectionsAsync(string partitionKey, CancellationToken cancellationToken);

    Task Upsert(ICollection<IProjection> generatedProjections, CancellationToken cancellationToken);
}