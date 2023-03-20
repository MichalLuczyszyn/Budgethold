using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Api")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Integration.Tests")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Unit.Tests")]

namespace Budgethold.Modules.Wallets.Core;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        => serviceCollection;
}
