using Microsoft.AspNetCore.Identity;
using Oekaki.Data;
using Oekaki.Data.Models;

namespace Oekaki.Core.Services;

public static class AuthenticationServices
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();

        services.Configure<IdentityOptions>(options =>
        {
            // TO-DO: create a config file (JSON, YAML or TOML)
            // to allow the sysadmin to change these options
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;

            // May need more configuration if we want to allow other
            // writing systems (e.g. Kana, Hanzi, etc.)
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_";
            options.User.RequireUniqueEmail = true;
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "OekakiIdentity";
        });

        services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
