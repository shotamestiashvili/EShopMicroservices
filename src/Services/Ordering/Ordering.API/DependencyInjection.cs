namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApinServices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseApiService(this WebApplication app)
    {
        return app;
    }
}