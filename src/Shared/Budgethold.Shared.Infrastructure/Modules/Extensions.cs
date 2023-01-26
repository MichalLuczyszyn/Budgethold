namespace Budgethold.Shared.Infrastructure.Modules;

using Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Extensions
{
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
