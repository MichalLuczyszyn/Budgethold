using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Api")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Application")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Infrastructure")]

namespace Budgethold.Modules.Wallets.Domain;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection) => serviceCollection;
}
