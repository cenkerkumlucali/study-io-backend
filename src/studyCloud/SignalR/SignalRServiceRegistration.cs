using Microsoft.Extensions.DependencyInjection;

namespace SignalR;

public static class SignalRServiceRegistration
{
    public static IServiceCollection AddSignalRServices(this IServiceCollection services)
    {
        services.AddSignalR();
        return services;
    }
}