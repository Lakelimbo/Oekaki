using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.OpenApi.Models;

namespace Oekaki.Core.Services;

public static class RoutesServices
{
    public static IServiceCollection AddRoutes(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
