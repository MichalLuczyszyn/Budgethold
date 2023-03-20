namespace Budgethold.Shared.Infrastructure.Queries;

using System.Reflection;
using Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        serviceCollection.Scan(x => x.FromAssemblies(assemblies).AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return serviceCollection;
    }
}
