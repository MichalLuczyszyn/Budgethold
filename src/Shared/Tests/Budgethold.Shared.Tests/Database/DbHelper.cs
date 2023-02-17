namespace Budgethold.Shared.Tests.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Settings;

public static class DbHelper
{
    private static readonly IConfiguration Configuration = OptionsHelper.GetConfigurationRoot();

    public static DbContextOptions<T> GetOptions<T>(bool useRandomDatabaseIdentifier = true) where T : DbContext
    {
        const string databaseName = $"budgethold-test";
        var connectionString = Configuration["postgres:connectionString"];
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            var database = useRandomDatabaseIdentifier ? $"{databaseName}-{Guid.NewGuid():N}" : databaseName;
            connectionString = $"Host=localhost;Database={database};Username=postgres;Password=";
        }

        return new DbContextOptionsBuilder<T>()
            .UseNpgsql(connectionString)
            .EnableSensitiveDataLogging()
            .Options;
    }
}