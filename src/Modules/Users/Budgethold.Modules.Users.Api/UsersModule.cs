namespace Budgethold.Modules.Users.Api
{
    using System.Collections.Generic;
    using Core;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Shared.Abstractions.Modules;

    internal class UsersModule : IModule
    {
        public const string BasePath = "users-module";        
        public string Name { get; } = "Users";
        public string Path => BasePath;
        
        public IEnumerable<string> Policies { get; } = new[]
        {
            "users"
        };

        public void Register(IServiceCollection services) => services.AddCore();

        public void Use(IApplicationBuilder app)
        {
        }
    }
}