using ColmadoYa.Application.Interfaces;
using ColmadoYa.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ColmadoYa.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}