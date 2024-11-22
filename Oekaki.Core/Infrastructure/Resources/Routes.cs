namespace Oekaki.Core.Infrastructure.Resources;

public static class Routes
{
    public static IServiceCollection AddRoutes(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
