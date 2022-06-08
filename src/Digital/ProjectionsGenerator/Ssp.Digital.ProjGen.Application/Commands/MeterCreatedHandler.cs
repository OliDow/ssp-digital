using MediatR;
using Ssp.Common.Data.Projections;
using Ssp.EP.Events.Source;

namespace Ssp.Digital.ProjGen.Application.Commands;

public class MeterCreatedHandler : ProjectionProcessorBase, IProjectionUpdateHandler<MeterCreated>
{
    public MeterCreatedHandler(IProjectionRepository projectionRepository, IList<IProjectionGenerator> projectionGenerators)
        : base(projectionRepository, projectionGenerators) { }

    public Task<Unit> Handle(MeterCreated request, CancellationToken cancellationToken)
        => GetProjectionData(request, request.MeterPointNumber, cancellationToken);
}