
namespace Bookify.Infrastructure.Authorization;

public interface IAuthorizationService
{
    Task<UserRolesResponse> GetRolesForUserAsync(string identityId);
}