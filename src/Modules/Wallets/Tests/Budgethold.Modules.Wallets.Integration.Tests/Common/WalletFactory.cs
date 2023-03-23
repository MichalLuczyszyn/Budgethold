namespace Budgethold.Modules.Wallets.Integration.Tests.Common;

using System.Text;
using System.Text.Json;
using Core.Commands.Wallets.Create;
using Core.Queries.Wallet.Get;
using Domain.Wallets.Entities;
using Domain.Wallets.ValueObjects;
using Shared.Abstractions.Kernel.Types;
using Shared.Tests.Helpers;

internal static class WalletFactory
{
    internal const string Uri = "http://localhost/wallets-module/Wallets";

    internal static readonly string FakerName = Faker.Name.First();
    internal static readonly Guid Id = WalletId.Create();

    internal static Wallet GetWallet(WalletId walletId) =>
        Wallet.Create(Id, FakerName, WalletType.Private);

    internal static GetWalletResponse GetWalletResponse() =>
        new GetWalletResponse(Id, FakerName, WalletType.Private);

    internal static GetWalletResponse GetWalletResponse(Guid id) =>
        new GetWalletResponse(id, FakerName, WalletType.Private);

    internal static HttpRequestMessage CreateWalletRequest()
    {
        var createWalletRequestContent = new StringContent(
            JsonSerializer.Serialize(new CreateWallet(FakerName)),
            Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, Uri);
        request.Content = createWalletRequestContent;
        return request;
    }

    internal static async Task<Guid> GetWalletGuid(HttpResponseMessage createWalletResponse)
    {
        createWalletResponse.EnsureSuccessStatusCode();

        var walletGuid = await ResponseDeserializer.GuidDeserializer(createWalletResponse);
        return walletGuid;
    }
}
