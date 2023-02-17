

using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Budgethold.Modules.Categories.Api")]

namespace Budgethold.Modules.Categories.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection) => serviceCollection;
}

