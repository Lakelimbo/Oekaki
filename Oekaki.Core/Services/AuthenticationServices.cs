using Oekaki.Data;
using Oekaki.Data.Models;

namespace Oekaki.Core.Services;

public static class AuthenticationServices
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();

        services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
