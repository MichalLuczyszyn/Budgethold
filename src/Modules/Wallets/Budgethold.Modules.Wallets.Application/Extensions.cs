using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Api")]

namespace Budgethold.Modules.Wallets.Core;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        => serviceCollection;
}
