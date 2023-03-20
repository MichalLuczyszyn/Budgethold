namespace Budgethold.Modules.Wallets.Core.Commands.Wallets.Update;

using Budgethold.Modules.Wallets.Core.Exceptions;
using Budgethold.Modules.Wallets.Domain.Wallets.Repositories;
using Budgethold.Shared.Abstractions.Commands;

internal class UpdateWalletHandler : ICommandHandler<UpdateWallet>
{
    private readonly IWalletRepository _walletRepository;

    public UpdateWalletHandler(IWalletRepository walletRepository) => _walletRepository = walletRepository;

    public async Task HandleAsync(UpdateWallet command, CancellationToken cancellationToken = default)
    {
        var isGivenNameAlreadyTaken = await _walletRepository.ExistAsync(command.Name, cancellationToken);

        if (isGivenNameAlreadyTaken) throw new WalletWithGivenNameAlreadyExistException();

        var wallet = await _walletRepository.GetAsync(command.Id, cancellationToken);

        if (wallet is null) throw new WalletWasNotFoundException();
        
        wallet.Update(command.Name);

        await _walletRepository.SaveChangeAsync(wallet, cancellationToken);
    }
}
