using Bookify.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Domain.Users;

public class User : IdentityUser<Guid>
{
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}