using Budgethold.Bootstrapper;
using Budgethold.Shared.Infrastructure;
using Budgethold.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

var _assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var _modules = ModuleLoader.LoadModules(_assemblies);

builder.Services.AddInfrastructure(_assemblies, _modules);
foreach (var module in _modules)
{
    module.Register(builder.Services);
}

var app = builder.Build();

app.UseInfrastructure();

foreach (var module in _modules)
{
    module.Use(app);
}

app.MapControllers();

_assemblies.Clear();
_modules.Clear();

app.Run();
