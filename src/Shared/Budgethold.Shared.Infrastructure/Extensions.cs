using System.Runtime.CompilerServices;
using Budgethold.Shared.Abstractions;
using Budgethold.Shared.Infrastructure.Api;
using Budgethold.Shared.Infrastructure.Exceptions;
using Budgethold.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Budgethold.Bootstrapper")]

namespace Budgethold.Shared.Infrastructure;

using System.Reflection;
using Abstractions.Modules;
using Auth;
using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Services;
using Swagger;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IList<Assembly> assemblies, IList<IModule> modules)
    {
        var disabledModules = new List<string>();
        using (var service = serviceCollection.BuildServiceProvider())
        {
            var confifuration = service.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in confifuration.AsEnumerable())
            {
                if (!key.Contains(":module:enabled"))
                {
                    continue;
                }

                if (value != null && !bool.Parse(value))
                {
                  disabledModules.Add(key.Split(":")[0]);  
                }
            }
        }
        
        serviceCollection.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            var removedParts = new List<ApplicationPart>();
            foreach (var parts in disabledModules.Select(disabled => manager.ApplicationParts.Where(x => x.Name.Contains(disabled, StringComparison.InvariantCultureIgnoreCase))))
            {
                removedParts.AddRange(parts);
            }

            foreach (var removedPart in removedParts)
            {
                manager.ApplicationParts.Remove(removedPart);
            }
            
            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });

        serviceCollection.AddSwaggerConfig();
        
        serviceCollection.AddSingleton<IContextFactory, ContextFactory>();
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        serviceCollection.AddTransient(sp => sp.GetRequiredService<IContextFactory>().Create());
        serviceCollection.AddAuth(modules);
        serviceCollection.AddHostedService<AppInitializer>();
        serviceCollection.AddErrorHandling();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSingleton<IClock, UtcClock>();

        return serviceCollection;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandling();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseReDoc(reDoc =>
        {
            reDoc.RoutePrefix = "docs";
            reDoc.SpecUrl("/swagger/v1/swagger.json");
            reDoc.DocumentTitle = "Confab API";
        });
        
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        return app;
    }

    public static T GetOptions<T>(this IServiceCollection serviceCollection, string sectionName) where T : new()
    {
        using var serviceProvider = serviceCollection.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        return configuration.GetOptions<T>(sectionName);
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);

        return options;
    }
    
    public static string GetModuleName(this object value)
        => value?.GetType().GetModuleName() ?? string.Empty;

    public static string GetModuleName(this Type type)
    {
        if (type?.Namespace is null)
        {
            return string.Empty;
        }

        return type.Namespace.StartsWith("Budgethold.Modules.")
            ? type.Namespace.Split(".")[2].ToLowerInvariant()
            : string.Empty;
    }
}