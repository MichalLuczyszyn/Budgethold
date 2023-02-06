using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Api")]

namespace Budgethold.Modules.Wallets.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection) => serviceCollection;
}
