using Bookify.Domain.Apartments;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Domain.Users;

public class Role : IdentityRole<Guid>
{
    public Description Description { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}