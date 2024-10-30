using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Users.LogInUser;

public class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenResponse>
{

    public async Task<Result<AccessTokenResponse>> Handle(
        LogInUserCommand request, 
        CancellationToken cancellationToken)
    {
        var result = Result.Success(new AccessTokenResponse(""));

        if (result.IsFailure)
        {
            return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);
        }

        return result.Value;
    }
}