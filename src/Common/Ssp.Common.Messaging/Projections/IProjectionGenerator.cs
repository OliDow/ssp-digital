namespace Ssp.Common.Messaging.Projections;

public interface IProjectionGenerator
{
    List<Type> UpdateEvent { get; }

    ICollection<IProjection> Generate(IEvent @event, IReadOnlyCollection<IProjection> projections);
}