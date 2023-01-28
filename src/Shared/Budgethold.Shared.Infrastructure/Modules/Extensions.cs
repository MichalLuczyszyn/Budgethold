namespace Budgethold.Shared.Infrastructure.Modules;

using System.Reflection;
using Abstractions.Events;
using Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Extensions
{
    private static void AddModuleRegistry(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        var registry = new ModuleRegistry();

        var types = assemblies.SelectMany(x => x.GetTypes()).ToArray();

        var eventTypes = types.Where(x => x.IsClass && typeof(IEvent).IsAssignableFrom(x)).ToArray();

        serviceCollection.AddSingleton<IModuleRegistry>(sp =>
        {
            var eventDispatcher = sp.GetRequiredService<IEventDispatcher>();
            var eventDispatcherType = eventDispatcher.GetType();

            foreach (var type in eventTypes)
                registry.AddBroadcastAction(type, @event =>
                    (Task)eventDispatcherType.GetMethod(nameof(eventDispatcher.PublishAsync))?.MakeGenericMethod(type).Invoke(eventDispatcher, new[] { @event }));
            
            return registry;
        });
    }

    internal static IServiceCollection AddModuleRequest(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
    {
        serviceCollection.AddModuleRegistry(assemblies);
        serviceCollection.AddSingleton<IModuleSerializer, JsonModuleSerializer>();
        serviceCollection.AddSingleton<IModuleClient, ModuleClient>();

        return serviceCollection;
    }

    internal static IServiceCollection AddModuleInfo(this IServiceCollection serviceCollection, IList<IModule> modules)
    {
        var moduleInfoProvider = new ModuleInfoProvider();
        var moduleInfo = modules?.Select(x => new ModuleInfo(x.Name, x.Path, x.Policies ?? Enumerable.Empty<string>())) ?? Enumerable.Empty<ModuleInfo>();

        moduleInfoProvider.ModuleInfos.AddRange(moduleInfo);
        serviceCollection.AddSingleton(moduleInfoProvider);

        return serviceCollection;
    }

    internal static void MapModuleInfo(this IEndpointRouteBuilder endpoint) =>
        endpoint.MapGet("modules", context =>
        {
            var moduleInfoProvider = context.RequestServices.GetRequiredService<ModuleInfoProvider>();
            return context.Response.WriteAsJsonAsync(moduleInfoProvider.ModuleInfos);
        });

    internal static IHostBuilder ConfigureModules(this IHostBuilder builder)
        => builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            foreach (var setting in GetSettings("*"))
            {
                cfg.AddJsonFile(setting);
            }

            foreach (var setting in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
            {
                cfg.AddJsonFile(setting);
            }


            IEnumerable<string> GetSettings(string pattern) => Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath,
                $"module.{pattern}.json", SearchOption.AllDirectories);
        });
}
