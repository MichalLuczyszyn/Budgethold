using System.Runtime.CompilerServices;
using Budgethold.Shared.Abstractions;
using Budgethold.Shared.Infrastructure.Api;
using Budgethold.Shared.Infrastructure.Exceptions;
using Budgethold.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Budgethold.Bootstrapper")]

namespace Budgethold.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });
        serviceCollection.AddErrorHandling();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
        serviceCollection.AddSingleton<IClock, UtcClock>();

        return serviceCollection;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandling();
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseHttpsRedirection();
        app.UseAuthorization();

        return app;
    }
}