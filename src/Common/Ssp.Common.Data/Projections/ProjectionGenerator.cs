namespace Ssp.Common.Data.Projections;

public class ProjectionGenerator : IProjectionGenerator
{
    public List<Type> UpdateEvent { get; protected init; } = new();

    public ICollection<IProjection> Generate(IEvent @event, IReadOnlyCollection<IProjection> projections)
    {
        var eventType = @event.GetType();
        if (!UpdateEvent.Contains(eventType))
        {
            throw new ArgumentException($"Supplied Event was not in UpdateEvent List");
        }

        return UpdateProjections(@event, projections);
    }

    protected virtual ICollection<IProjection> UpdateProjections(IEvent @event, IReadOnlyCollection<IProjection> projections)
        => throw new NotImplementedException();
}
