namespace Budgethold.Frontend.Shared;

using Microsoft.Extensions.DependencyInjection;
using Services;
using Wallets.Services;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IWalletsService, WalletsService>();
        services.AddScoped<ILocalStorageService, LocalStorageService>();

        return services;
    }
}
