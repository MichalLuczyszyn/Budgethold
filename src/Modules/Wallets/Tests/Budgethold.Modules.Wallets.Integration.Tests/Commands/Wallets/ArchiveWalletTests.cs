namespace Budgethold.Modules.Wallets.Integration.Tests.Commands.Wallets;

using System.Net;
using Common;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;
using Xunit;

public class ArchiveWalletTests : IClassFixture<WalletsTests>
{
    private readonly HttpClient _client;
    private Shared.Abstractions.IClock _calculator = Substitute.For<Shared.Abstractions.IClock>();

    public ArchiveWalletTests(WalletsTests client)
    {
        _client = client.CreateClient(new WebApplicationFactoryClientOptions());
    }

    [Fact]
    public async Task GIVEN_Wallet_Exist_SHOULD_Return_Success()
    {
        _calculator.CurrentDateTimeOffset().ReturnsForAnyArgs(new DateTimeOffset());
        var walletGuid = await CreateWallet();

        var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, WalletFactory.Uri + "/" + walletGuid);

        var deleteResponse = await _client.SendAsync(deleteRequest);
        deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task GIVEN_Wallet_Not_Exist_SHOULD_Return_Bad_Request()
    {
        _calculator.CurrentDateTimeOffset().ReturnsForAnyArgs(new DateTimeOffset());
        var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, WalletFactory.Uri + "/" + WalletFactory.Id);

        var deleteResponse = await _client.SendAsync(deleteRequest);
        deleteResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    private async Task<Guid> CreateWallet()
    {
        var request = WalletFactory.CreateWalletRequest();
        var createWalletResponse = await _client.SendAsync(request);
        return await WalletFactory.GetWalletGuid(createWalletResponse);
    }
}
