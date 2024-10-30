using Bookify.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Authorization;

public sealed class AuthorizationService : IAuthorizationService
{
    private readonly ApplicationDbContext _dbContext;

    public AuthorizationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserRolesResponse> GetRolesForUserAsync(string email)
    {
        var roles = await _dbContext
            .Set<User>()
            .Where(user => user.Email == email)
            .Select(user => new UserRolesResponse
            {
                Id = user.Id,
                Roles = user.UserRoles.Select(ur => ur.Role).ToList(),
            })
            .FirstAsync();
        return roles;
    }
}