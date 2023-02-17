namespace Budgethold.Modules.Wallets.Core.Commands.Create;

using Domain.Wallets.Entities;
using Domain.Wallets.Repositories;
using Domain.Wallets.ValueObjects;
using Exceptions;
using Shared.Abstractions.Commands;

internal class CreateWalletHandler : ICommandHandler<CreateWallet, WalletCreatedResponse>
{
    private readonly IWalletRepository _walletRepository;

    public CreateWalletHandler(IWalletRepository walletRepository) => _walletRepository = walletRepository;

    public async Task<WalletCreatedResponse> HandleAsync(CreateWallet command, CancellationToken cancellationToken = default)
    {
        var isGivenNameIsAlreadyTaken = await _walletRepository.ExistAsync(command.Name, cancellationToken);

        if (isGivenNameIsAlreadyTaken) throw new WalletWithGivenNameAlreadyExistException();

        var wallet = Wallet.Create(command.Name, WalletType.Private);

        await _walletRepository.AddAsync(wallet, cancellationToken);

        return new WalletCreatedResponse(wallet.Id);
    }
}
