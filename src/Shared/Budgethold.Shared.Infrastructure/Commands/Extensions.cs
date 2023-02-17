namespace Budgethold.Shared.Infrastructure.Commands;

using System.Reflection;
using Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        serviceCollection.Scan(x => x.FromAssemblies(assemblies).AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return serviceCollection;
    }
}
