using MediatR;

namespace Ssp.Common.Messaging.Projections;

public interface IProjectionUpdateHandler<in T> : IRequestHandler<T>
    where T : IRequest<Unit>
{ }