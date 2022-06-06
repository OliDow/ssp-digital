namespace Ssp.Common.Messaging.Projections;

public class ProjectionRepository : IProjectionRepository
{
    public async Task<IReadOnlyCollection<IProjection>> GetProjectionsAsync(string partitionKey,
        CancellationToken cancellationToken)
    {
        // todo Go to datasource to get Projections
        await Task.Delay(1, cancellationToken); // todo remove

        return new List<IProjection>();
    }

    public async Task Upsert(ICollection<IProjection> generatedProjections, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken); // todo remove
    }
}