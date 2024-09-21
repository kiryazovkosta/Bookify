namespace Bookify.Application.Users.GetLoggedInUser;

public sealed class UserResponse
{
    public Guid Id { get; init; }

    public required string Email { get; init; }

    public required string Name { get; init; }
}