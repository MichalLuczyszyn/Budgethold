using System.Runtime.CompilerServices;
using Budgethold.Modules.Wallets.Core;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Budgethold.Bootstrapper")]

namespace Budgethold.Modules.Wallets.Api;

internal static class Extensions
{
    public static IServiceCollection AddWallets(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCore();
        
        return serviceCollection;
    }
}