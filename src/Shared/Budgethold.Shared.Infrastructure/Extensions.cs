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
using Amazon;
using Amazon.Extensions.Configuration.SystemsManager;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Commands;
using Contexts;
using Events;
using Kernel;
using Messenger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Modules;
using Postgres;
using Queries;
using Serilog;
using Services;
using Swagger;

internal static class Extensions
{
    private const string CorsPolicy = "cors";

    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        IList<Assembly> assemblies, IList<IModule> modules, WebApplicationBuilder webApplicationBuilder)
    {
        ConfigureAwsSecretsManager(webApplicationBuilder);

        ConfigureAuthentication(serviceCollection, webApplicationBuilder);

        ManageRemovedModules(serviceCollection);

        serviceCollection.AddSwaggerConfig();

        ConfigureCors(serviceCollection);

        serviceCollection.AddRouting(options => options.LowercaseUrls = true);
        serviceCollection.AddSingleton<IContextFactory, ContextFactory>();
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        serviceCollection.AddTransient(sp => sp.GetRequiredService<IContextFactory>().Create());
        serviceCollection.AddEvents(assemblies);
        serviceCollection.AddCommands(assemblies);
        serviceCollection.AddDomainEventDispatcher(assemblies);
        serviceCollection.AddQueries(assemblies);
        serviceCollection.AddModuleRequest(assemblies);
        serviceCollection.AddModuleInfo(modules);
        serviceCollection.AddHostedService<AppInitializer>();
        serviceCollection.AddPostgres();
        serviceCollection.AddMessenger();
        serviceCollection.AddErrorHandling();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSingleton<IClock, UtcClock>();

        return serviceCollection;
    }

    private static void ConfigureCors(IServiceCollection serviceCollection) =>
        serviceCollection.AddCors(cors =>
        {
            cors.AddPolicy(CorsPolicy, x =>
            {
                x.WithOrigins("*")
                    .WithMethods("POST", "PUT", "DELETE")
                    .WithHeaders("Content-Type", "Authorization");
            });
        });

    private static void ManageRemovedModules(IServiceCollection serviceCollection)
    {
        var disabledModules = ConfigureDisabledModules(serviceCollection);

        serviceCollection.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            var removedParts = new List<ApplicationPart>();
            foreach (var parts in disabledModules.Select(disabled =>
                         manager.ApplicationParts.Where(x =>
                             x.Name.Contains(disabled, StringComparison.InvariantCultureIgnoreCase))))
                removedParts.AddRange(parts);

            foreach (var removedPart in removedParts) manager.ApplicationParts.Remove(removedPart);

            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });
    }

    private static List<string> ConfigureDisabledModules(IServiceCollection serviceCollection)
    {
        var disabledModules = new List<string>();
        using var service = serviceCollection.BuildServiceProvider();
        var configuration = service.GetRequiredService<IConfiguration>();
        foreach (var (key, value) in configuration.AsEnumerable())
        {
            if (!key.Contains(":module:enabled")) continue;

            if (value != null && !bool.Parse(value)) disabledModules.Add(key.Split(":")[0]);
        }

        return disabledModules;
    }

    private static void ConfigureAwsSecretsManager(WebApplicationBuilder webApplicationBuilder)
    {
        if (webApplicationBuilder.Environment.IsDevelopment()) return;
        
        var env = webApplicationBuilder.Environment.EnvironmentName.ToLowerInvariant();
        var appName = webApplicationBuilder.Environment.ApplicationName.ToLowerInvariant().Split(".").First();

        webApplicationBuilder.Configuration.AddSecretsManager(region: RegionEndpoint.EUNorth1,
            configurator: options =>
            {
                options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}_");
                options.KeyGenerator = (_, s) => s
                    .Replace($"{env}_{appName}_", string.Empty)
                    .Replace("__", ":");
                options.PollingInterval = TimeSpan.FromMinutes(10);
            });

    }

    private static void ConfigureAuthentication(IServiceCollection serviceCollection,
        WebApplicationBuilder webApplicationBuilder)
    {
        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
        {
            c.Authority = webApplicationBuilder.Configuration["Auth0:Authority"];
            c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidAudiences =
                    new List<string>() { webApplicationBuilder.Configuration["Auth0:Audience"] },
                ValidIssuers = new List<string>() { webApplicationBuilder.Configuration["Auth0:Authority"] },
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        serviceCollection.AddAuthorization(o =>
        {
            o.AddPolicy("wallets:read-write",
                p => p.RequireAuthenticatedUser().RequireClaim("permissions", "wallets:read-write"));

            o.AddPolicy("categories:read-write",
                p => p.RequireAuthenticatedUser().RequireClaim("permissions", "categories:read-write"));

            o.AddPolicy("repeatabletransactions:read-write",
                p => p.RequireAuthenticatedUser().RequireClaim("permissions", "repeatabletransactions:read-write"));

            o.AddPolicy("transactions:read-write",
                p => p.RequireAuthenticatedUser().RequireClaim("permissions", "transactions:read-write"));
        });
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseCors(CorsPolicy);
        app.UseErrorHandling();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseAuthentication();
        app.UseSerilogRequestLogging();
        app.UseAuthorization();

        return app;
    }

    public static T GetOptions<T>(this IServiceCollection serviceCollection, string sectionName) where T : new()
    {
        using var serviceProvider = serviceCollection.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        return configuration.GetOptions<T>(sectionName);
    }

    private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);

        return options;
    }

    public static string GetModuleName(this object value)
        => value?.GetType().GetModuleName() ?? string.Empty;

    private static string GetModuleName(this Type type)
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
