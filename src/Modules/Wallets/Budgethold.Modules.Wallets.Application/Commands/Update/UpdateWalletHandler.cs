namespace Budgethold.Modules.Wallets.Core.Commands.Update;

using Domain.Wallets.Repositories;
using Exceptions;
using Shared.Abstractions.Commands;

internal class UpdateWalletHandler : ICommandHandler<UpdateWallet>
{
    private readonly IWalletRepository _walletRepository;

    public UpdateWalletHandler(IWalletRepository walletRepository) => _walletRepository = walletRepository;

    public async Task HandleAsync(UpdateWallet command, CancellationToken cancellationToken = default)
    {
        var isGivenNameIsAlreadyTaken = await _walletRepository.ExistAsync(command.Name, cancellationToken);

        if (isGivenNameIsAlreadyTaken) throw new WalletWithGivenNameAlreadyExistException();

        var wallet = await _walletRepository.GetAsync(command.Id, cancellationToken);

        if (wallet is null) throw new WalletWasNotFoundException();
        
        wallet.Update(command.Name);

        await _walletRepository.SaveChangeAsync(wallet, cancellationToken);
    }
}
