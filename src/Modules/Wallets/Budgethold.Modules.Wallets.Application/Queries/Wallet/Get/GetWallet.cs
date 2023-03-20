namespace Budgethold.Modules.Wallets.Core.Queries.Wallet.Get;

using Shared.Abstractions.Queries;

public record GetWallet(Guid Id) : IQuery<GetWalletResponse>;
