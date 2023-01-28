namespace Budgethold.Shared.Infrastructure.Events;

using System.Reflection;
using Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddEvents(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<IEventDispatcher, EventDispatcher>();
        serviceCollection.Scan(x => x.FromAssemblies(assemblies).AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return serviceCollection;
    }
}
