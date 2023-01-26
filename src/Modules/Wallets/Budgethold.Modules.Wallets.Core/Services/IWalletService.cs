namespace Budgethold.Modules.Wallets.Core.Services;

using Dtos;
using Entities;
using Shared.Infrastructure.Dtos;

public interface IWalletService
{
    Task<WalletResponseDto> GetAsync(Guid walletId);
    Task<ObjectCreatedDto> CreateAsync(WalletDto walletDto);
    Task UpdateAsync(Guid walletId, WalletDto walletDto);
    Task DeleteAsync(Guid walletId);
}