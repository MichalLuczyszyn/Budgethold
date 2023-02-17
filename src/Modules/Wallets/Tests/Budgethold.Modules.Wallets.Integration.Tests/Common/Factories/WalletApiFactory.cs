namespace Budgethold.Modules.Wallets.Integration.Tests.Common.Factories;

using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared.Tests.Context;
using Xunit;

public class WalletApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlTestcontainer _dbContainer =
        new ContainerBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration()
            {
                Database = "wallet_test_db", Username = "postgres", Password = ""
            })
            .WithImage("postgres:latest")
            .WithCleanUp(true)
            .Build();


    protected override void ConfigureWebHost(IWebHostBuilder builder) =>
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(FakeContext));
            services.AddSingleton<FakeContext>();
        });

    public async Task InitializeAsync() => await _dbContainer.StartAsync();

    public new async Task DisposeAsync() => await _dbContainer.StopAsync();
}
