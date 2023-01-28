using Budgethold.Bootstrapper;
using Budgethold.Shared.Infrastructure;
using Budgethold.Shared.Infrastructure.Modules;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

var _assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var _modules = ModuleLoader.LoadModules(_assemblies);

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(logger);

builder.Services.AddInfrastructure(_assemblies, _modules);
foreach (var module in _modules)
{
    module.Register(builder.Services);
}

Log.CloseAndFlush();

var app = builder.Build();

app.UseInfrastructure();

foreach (var module in _modules)
{
    module.Use(app);
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapModuleInfo();
});

_assemblies.Clear();
_modules.Clear();

app.Run();
