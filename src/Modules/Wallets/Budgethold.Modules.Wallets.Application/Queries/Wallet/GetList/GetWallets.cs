namespace Budgethold.Modules.Wallets.Core.Queries.Wallet.GetList;

using Shared.Abstractions.Queries;

public record GetWallets() : IQuery<ICollection<GetWalletsResponse>>;
