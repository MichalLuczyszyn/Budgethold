namespace Budgethold.Modules.Wallets.Core.Commands.Archive;

using Budgethold.Modules.Wallets.Domain.Wallets.Repositories;
using Budgethold.Shared.Abstractions.Commands;
using Exceptions;
using Shared.Abstractions;

internal class ArchiveWalletHandler : ICommandHandler<ArchiveWallet>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IClock _clock;

    public ArchiveWalletHandler(IWalletRepository walletRepository, IClock clock)
    {
        _walletRepository = walletRepository;
        _clock = clock;
    }

    public async Task HandleAsync(ArchiveWallet command, CancellationToken cancellationToken = default)
    {
        var wallet = await _walletRepository.GetAsync(command.Id, cancellationToken);

        if (wallet is null) throw new WalletWasNotFoundException();
        
        wallet.Archive(_clock.CurrentDateTimeOffset());
        
        await _walletRepository.SaveChangeAsync(wallet, cancellationToken);
    }
}
