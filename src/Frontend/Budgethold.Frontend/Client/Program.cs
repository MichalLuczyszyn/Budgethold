using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Budgethold.Frontend.Client;
using Budgethold.Frontend.Shared;
using Budgethold.Frontend.Shared.Shared.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

const string budgetholdapi = "BudgetholdAPI";

builder.Services.AddHttpClient(budgetholdapi, client =>
    {
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        client.Timeout = new TimeSpan(0, 0, 30);
    })
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient(budgetholdapi));

builder.Services.AddScoped<IHttpClient, CustomHttpClient>();
builder.Services.AddScoped<IApiResponseHandler, ApiResponseHandler>();
builder.Services.AddCore();
builder.Services.AddAntDesign();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});


await builder.Build().RunAsync();
