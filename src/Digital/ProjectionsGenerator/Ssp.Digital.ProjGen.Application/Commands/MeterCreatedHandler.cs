using MediatR;
using Ssp.Common.Data.Projections;
using Ssp.EP.Events.Source;

namespace Ssp.Digital.ProjGen.Application.Commands;

public class MeterCreatedHandler : ProjectionProcessorBase, IProjectionUpdateHandler<Meter>
{
    public MeterCreatedHandler(IProjectionRepository projectionRepository, IList<IProjectionGenerator> projectionGenerators)
        : base(projectionRepository, projectionGenerators) { }

    public Task<Unit> Handle(Meter request, CancellationToken cancellationToken)
        => GetProjectionData(request, request.SerialNumber, cancellationToken);
}