using Budgethold.Modules.Wallets.Api;
using Budgethold.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddWallets();

var app = builder.Build();

app.UseInfrastructure();

app.MapControllers();

app.Run();