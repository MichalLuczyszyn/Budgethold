namespace Budgethold.Shared.Abstractions.Modules;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public interface IModule
{
    string Name { get;}
    string Path { get;}
    IEnumerable<string> Policies => null;

    void Register(IServiceCollection serviceCollection);
    void Use(IApplicationBuilder applicationBuilder);
}
