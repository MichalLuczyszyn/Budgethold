using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Budgethold.Modules.Users.Api")]

namespace Budgethold.Modules.Users.Core
{
    using DAL;
    using DAL.Repositories;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;
    using Shared.Infrastructure.Postgres;

    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<IUserRepository, UserRepository>()
                .AddPostgres<UsersDbContext>();
    }
}
