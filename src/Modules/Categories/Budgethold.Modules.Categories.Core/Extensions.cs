using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budgethold.Modules.Categories.Api")]

namespace Budgethold.Modules.Categories.Core
{
    using DAL;
    using DAL.Repositories;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;
    using Services;
    using Shared.Infrastructure.Postgres;

    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddPostgres<CategoriesDbContext>();
    }
}
