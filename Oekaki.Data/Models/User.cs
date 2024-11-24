using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Oekaki.Shared.Extensions;

namespace Oekaki.Data.Models;

public class User : IdentityUser
{
    private string _nickname = string.Empty;

    [Required]
    public string Nickname
    {
        get => _nickname;
        set
        {
            _nickname = value;
            URISlug = value.Slugify();
        }
    }

    [Required]
    public string URISlug { get; set; } = string.Empty;

    public virtual ICollection<UserClaim> Claims { get; set; } = [];
    public virtual ICollection<UserLogin> Logins { get; set; } = [];
    public virtual ICollection<UserToken> Tokens { get; set; } = [];
    public virtual ICollection<UserRole> UserRoles { get; set; } = [];
};

public class UserRole : IdentityUserRole<string>
{
    public virtual User User { get; set; } = new User();
    public virtual Role Role { get; set; } = new Role();
}

public class UserClaim : IdentityUserClaim<string>
{
    public virtual User User { get; set; } = new User();
}

public class UserLogin : IdentityUserLogin<string>
{
    public virtual User User { get; set; } = new User();
}

public class UserToken : IdentityUserToken<string>
{
    public virtual User User { get; set; } = new User();
}
