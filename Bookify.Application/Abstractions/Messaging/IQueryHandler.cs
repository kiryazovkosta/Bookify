using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

using Domain.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}