
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budgethold.Modules.Categories.Api")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Categories.Application")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Categories.Infrastructure")]

namespace Budgethold.Modules.Categories.Domain;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection) => serviceCollection;
}

