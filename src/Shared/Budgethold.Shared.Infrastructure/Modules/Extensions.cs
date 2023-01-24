namespace Budgethold.Shared.Infrastructure.Modules;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

public static class Extensions
{
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
