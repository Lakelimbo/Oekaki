using Microsoft.AspNetCore.Identity;

namespace Oekaki.Data.Models;

public class Role : IdentityRole
{
    public virtual ICollection<UserRole> UserRoles { get; set; } = [];
    public virtual ICollection<RoleClaim> RoleClaims { get; set; } = [];
}

public class RoleClaim : IdentityRoleClaim<string>
{
    public virtual Role Role { get; set; } = new Role();
}
