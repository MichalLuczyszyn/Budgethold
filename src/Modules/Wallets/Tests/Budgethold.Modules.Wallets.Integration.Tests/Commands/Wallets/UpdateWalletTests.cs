namespace Budgethold.Modules.Wallets.Integration.Tests.Commands.Wallets;

using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Common;
using Core.Commands.Wallets.Update;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

public class UpdateWalletTests : IClassFixture<WalletsTests>
{
    private readonly HttpClient _client;
    private readonly Shared.Abstractions.IClock _calculator = Substitute.For<Shared.Abstractions.IClock>();

    public UpdateWalletTests(WalletsTests client)
    {
        _client = client.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication("Bearer")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Auth0", options => { });
            });
        }).CreateClient(new WebApplicationFactoryClientOptions() { AllowAutoRedirect = false });

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Auth0");
    }

    [Fact]
    public async Task GIVEN_Wallet_Exist_SHOULD_Return_Success()
    {
        _calculator.CurrentDateTimeOffset().ReturnsForAnyArgs(new DateTimeOffset());
        var walletGuid = await CreateWallet();

        var updateRequestContent =
            new StringContent(JsonSerializer.Serialize(new UpdateWalletRequest("string")), Encoding.UTF8, "application/json");
        var updateRequest = new HttpRequestMessage(HttpMethod.Put, WalletFactory.Uri + "/" + walletGuid);
        updateRequest.Content = updateRequestContent;

        var updateResponse = await _client.SendAsync(updateRequest);
        updateResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task GIVEN_Wallet_Not_Exist_SHOULD_Return_Bad_Request()
    {
        _calculator.CurrentDateTimeOffset().ReturnsForAnyArgs(new DateTimeOffset());
        var updateRequestContent =
            new StringContent(JsonSerializer.Serialize(new UpdateWalletRequest("string")), Encoding.UTF8, "application/json");
        var updateRequest = new HttpRequestMessage(HttpMethod.Put, WalletFactory.Uri + "/" + WalletFactory.Id);
        updateRequest.Content = updateRequestContent;

        var updateResponse = await _client.SendAsync(updateRequest);
        updateResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    private async Task<Guid> CreateWallet()
    {
        var request = WalletFactory.CreateWalletRequest();
        var createWalletResponse = await _client.SendAsync(request);
        return await WalletFactory.GetWalletGuid(createWalletResponse);
    }
}
