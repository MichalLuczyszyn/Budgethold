namespace Budgethold.Shared.Infrastructure.Postgres;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection serviceCollection)
    {
        var options = serviceCollection.GetOptions<PostgresOptions>("postgres");
        serviceCollection.AddSingleton(options);
        
        return serviceCollection;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection serviceCollection) where T : DbContext
    {
        var options = serviceCollection.GetOptions<PostgresOptions>("postgres");
        serviceCollection.AddDbContext<T>(x => x.UseNpgsql(options.ConnectionString));

        return serviceCollection;
    }
}
