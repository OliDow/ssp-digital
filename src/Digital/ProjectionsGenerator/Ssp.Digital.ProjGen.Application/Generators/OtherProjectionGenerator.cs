using Ssp.Common;
using Ssp.Common.Data.Projections;

namespace Ssp.Digital.ProjGen.Application.Generators;

public class OtherProjectionGenerator : IProjectionGenerator
{
    public List<Type> UpdateEvent { get; } = new() { };

    public ICollection<IProjection> Generate(IEvent @event, IReadOnlyCollection<IProjection> projection)
    {
        // todo Abstract boiler plate code
        var eventType = @event.GetType();
        if (!UpdateEvent.Contains(eventType))
        {
            throw new ArgumentException($"Supplied Event was not in UpdateEvent List");
        }

        return new List<IProjection>();
    }
}