namespace Budgethold.Shared.Tests.Database;

using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;

public class SharedContextContainer 
{
    private static readonly PostgreSqlTestcontainerConfiguration Database = new()
    {
        Database = "db", Username = "postgres", Password = "Pa$$w00rd"
    };

    public static readonly TestcontainerDatabase TestContainerDatabase =
        new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(Database)
            .WithWaitStrategy(Wait.ForUnixContainer())
            .Build();

    public string ConnectionString => TestContainerDatabase.ConnectionString;

    public Task StartAsync() => TestContainerDatabase.StartAsync();

    public Task Stop() => TestContainerDatabase.DisposeAsync().AsTask();

}