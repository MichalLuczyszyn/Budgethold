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

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddInfrastructure(_assemblies, _modules, builder);
foreach (var module in _modules)
{
    module.Register(builder.Services);
}

Log.CloseAndFlush();

var app = builder.Build();

app.UseInfrastructure();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

foreach (var module in _modules)
{
    module.Use(app);
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapModuleInfo();
});

_assemblies.Clear();
_modules.Clear();

app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }
