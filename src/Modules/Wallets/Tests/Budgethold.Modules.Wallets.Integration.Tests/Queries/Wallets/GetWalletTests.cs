namespace Budgethold.Modules.Wallets.Integration.Tests.Queries.Wallets;

using System.Net;
using System.Text.Json;
using Common;
using Core.Queries.Wallet.Get;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;
using Shared.Tests.Helpers;
using Xunit;

public class GetWalletTests : IClassFixture<WalletsTests>
{
    private readonly HttpClient _client;
    private Shared.Abstractions.IClock _calculator = Substitute.For<Shared.Abstractions.IClock>();

    public GetWalletTests(WalletsTests client) => _client = client.CreateClient(new WebApplicationFactoryClientOptions());

    [Fact]
    public async Task GIVEN_Wallet_Exist_SHOULD_Return_Success()
    {
        _calculator.CurrentDateTimeOffset().ReturnsForAnyArgs(new DateTimeOffset());
        var walletGuid = await CreateWallet();
        
        var getRequest = new HttpRequestMessage(HttpMethod.Get, WalletFactory.Uri + "/" + walletGuid);

        var getResponse = await _client.SendAsync(getRequest);
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var response = await ResponseDeserializer.GetDeserializedResponse<GetWalletResponse>(getResponse);

        response.Should().Be(WalletFactory.GetWalletResponse(walletGuid));
    }

    [Fact]
    public async Task GIVEN_Wallet_Not_Exist_SHOULD_Return_Not_Found()
    {
        _calculator.CurrentDateTimeOffset().ReturnsForAnyArgs(new DateTimeOffset());
        var getRequest = new HttpRequestMessage(HttpMethod.Get, WalletFactory.Uri + "/" + WalletFactory.Id);

        var getResponse = await _client.SendAsync(getRequest);
        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    private async Task<Guid> CreateWallet()
    {
        var request = WalletFactory.CreateWalletRequest();
        var createWalletResponse = await _client.SendAsync(request);
        return await WalletFactory.GetWalletGuid(createWalletResponse);
    }
}
