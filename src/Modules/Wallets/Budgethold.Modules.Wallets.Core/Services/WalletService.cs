namespace Budgethold.Modules.Wallets.Core.Services;

using Dtos;
using Entities;
using Exceptions;
using Repositories;
using Shared.Infrastructure.Dtos;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository) => _walletRepository = walletRepository;

    public async Task<WalletResponseDto> GetAsync(Guid walletId)
    {
        var wallet = await _walletRepository.GetAsync(walletId);

        if (wallet is null) throw new WalletNotFoundException();

        return new WalletResponseDto(wallet.Id, wallet.Name);
    }

    public async Task<ObjectCreatedDto> CreateAsync(WalletDto walletDto)
    {
        var wallet = new Wallet(walletDto.Name);

        await _walletRepository.AddAsync(wallet);

        return new ObjectCreatedDto(wallet.Id);
    }

    public async Task UpdateAsync(Guid walletId, WalletDto walletDto)
    {
        var wallet = await _walletRepository.GetAsync(walletId);

        if (wallet is null) throw new WalletNotFoundException();
        
        wallet.Update(walletDto.Name);

        await _walletRepository.UpdateAsync(wallet);
    }

    public async Task DeleteAsync(Guid walletId)
    {
        var wallet = await _walletRepository.GetAsync(walletId);

        if (wallet is null) throw new WalletNotFoundException();

        await _walletRepository.DeleteAsync(wallet);
    }
}
