using Ssp.Common;
using Ssp.Common.Data.Projections;

namespace Ssp.Digital.ProjGen.Application.Generators;

public class OtherProjectionGenerator : ProjectionGenerator
{
    public OtherProjectionGenerator()
    {
        UpdateEvent = new List<Type>();
    }

    protected override ICollection<IProjection> UpdateProjections(IEvent @event,
        IReadOnlyCollection<IProjection> projections) => new List<IProjection>();
}