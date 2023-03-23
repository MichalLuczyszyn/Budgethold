namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Queries;

using Context;
using Core.Queries.Wallet.Get;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions.Queries;

internal class GetWalletHandler : IQueryHandler<GetWallet, GetWalletResponse>
{
    private readonly WalletsReadDbContext _dbContext;

    public GetWalletHandler(WalletsReadDbContext dbContext) => _dbContext = dbContext;

    public async Task<GetWalletResponse?> HandleAsync(GetWallet query)
    {
        var result = await _dbContext.Wallets.Where(x => x.Id == query.Id).Select(x => new GetWalletResponse(x.Id, x.Name, x.WalletType)).FirstOrDefaultAsync();

        return result;
    }
}
