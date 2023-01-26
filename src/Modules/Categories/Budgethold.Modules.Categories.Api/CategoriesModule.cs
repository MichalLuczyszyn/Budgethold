namespace Budgethold.Modules.Categories.Api
{
    using System.Collections.Generic;
    using Core;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Shared.Abstractions.Modules;

    internal class CategoriesModule : IModule
    {
        public const string BasePath = "categories-module";        
        public string Name { get; } = "Categories";
        public string Path => BasePath;
        
        public IEnumerable<string> Policies { get; } = new[]
        {
            "categories"
        };

        public void Register(IServiceCollection services) => services.AddCore();

        public void Use(IApplicationBuilder app)
        {
        }
    }
}