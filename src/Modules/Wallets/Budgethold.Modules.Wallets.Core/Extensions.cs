using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Budgethold.Modules.Wallets.Api")]

namespace Budgethold.Modules.Wallets.Core;

using DAL;
using Budgethold.Modules.Wallets.Core.DAL.Repositories;
using Repositories;
using Services;
using Shared.Infrastructure.Postgres;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        =>
            serviceCollection.AddPostgres<WalletsDbContext>()
                .AddScoped<IWalletService, WalletService>()
                .AddScoped<IWalletRepository, WalletRepository>()
                .AddScoped<ITransactionRepository, TransactionRepository>();
}
