namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Queries;

using Context;
using Core.Queries.Wallet.GetList;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions.Queries;

internal class GetWalletsHandler : IQueryHandler<GetWallets, ICollection<GetWalletsResponse>>
{
    private readonly WalletsReadDbContext _dbContext;

    public GetWalletsHandler(WalletsReadDbContext dbContext) => _dbContext = dbContext;

    public async Task<ICollection<GetWalletsResponse>> HandleAsync(GetWallets query)
    {
        var result = await _dbContext.Wallets.Select(x => new GetWalletsResponse(x.Id, x.Name, x.WalletType)).ToListAsync();
        
        return result;
    }
}
