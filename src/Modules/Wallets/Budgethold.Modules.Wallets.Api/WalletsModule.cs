namespace Budgethold.Modules.Wallets.Api;

using Core;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.Modules;

public class WalletsModule : IModule
{
    public const string BasePath = "wallets-module";
    
    public string Name { get; } = "Wallets";
    public string Path { get; } = BasePath;

    public IEnumerable<string> Policies { get; } = new[]
    {
        "wallets", "transactions"
    };
    
    public void Register(IServiceCollection serviceCollection) => serviceCollection.AddApplication().AddDomain().AddInfrastructure();

    public void Use(IApplicationBuilder applicationBuilder)
    {
    }
}
