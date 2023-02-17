using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budgethold.Modules.Categories.Api")]

namespace Budgethold.Modules.Categories.Infrastructure
{
    using Budgethold.Modules.Categories.Core.Repositories;
    using Budgethold.Shared.Infrastructure.Postgres;
    using DAL;
    using DAL.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddPostgres<CategoriesDbContext>();
    }
}
