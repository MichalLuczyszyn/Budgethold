namespace Budgethold.Shared.Infrastructure.Kernel;

using System.Reflection;
using Abstractions.Kernel;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddDomainEventDispatcher(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        serviceCollection.Scan(x => x.FromAssemblies(assemblies).AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return serviceCollection;
    }
}
