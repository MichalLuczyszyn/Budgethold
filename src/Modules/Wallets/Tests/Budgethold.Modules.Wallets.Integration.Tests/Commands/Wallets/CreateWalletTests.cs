namespace Budgethold.Modules.Wallets.Integration.Tests.Commands.Wallets;

using System.Net;
using System.Text;
using System.Text.Json;
using Common;
using Core.Commands.Wallets.Create;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class CreateWalletTests : IClassFixture<WalletsTests>
{
    private readonly HttpClient _client;

    public CreateWalletTests(WalletsTests client) => _client = client.CreateClient(new WebApplicationFactoryClientOptions());

    [Fact]
    public async Task GIVEN_Valid_Wallet_Name_SHOULD_Return_Success()
    {
        var requestContent = new StringContent(JsonSerializer.Serialize(new CreateWallet(WalletFactory.FakerName)),
            Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, WalletFactory.Uri);
        request.Content = requestContent;

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GIVEN_Invalid_Wallet_Name_SHOULD_Return_Bad_Request()
    {
        var emptyString = "";
        var requestContent =
            new StringContent(JsonSerializer.Serialize(new CreateWallet(emptyString)), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, WalletFactory.Uri);
        request.Content = requestContent;

        var response = await _client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
