using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Api")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Integration.Tests")]
[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Unit.Tests")]

namespace Budgethold.Modules.Wallets.Infrastructure;

using DAL.Context;
using DAL.Wallets.Repositories;
using Domain.Wallets.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Postgres;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddPostgres<WalletsReadDbContext>()
            .AddPostgres<WalletsWriteDbContext>();
        
        serviceCollection.AddScoped<IWalletRepository, WalletRepository>();

        return serviceCollection;
    }
}
