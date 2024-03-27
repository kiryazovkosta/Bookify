using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

using Domain.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}