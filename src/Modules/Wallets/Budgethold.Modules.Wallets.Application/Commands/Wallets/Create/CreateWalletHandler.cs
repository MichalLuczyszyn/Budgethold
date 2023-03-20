namespace Budgethold.Modules.Wallets.Core.Commands.Wallets.Create;

using Budgethold.Modules.Wallets.Core.Exceptions;
using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Budgethold.Modules.Wallets.Domain.Wallets.Repositories;
using Budgethold.Modules.Wallets.Domain.Wallets.ValueObjects;
using Budgethold.Shared.Abstractions.Commands;
using Shared.Abstractions.Kernel.Types;

internal class CreateWalletHandler : ICommandHandler<CreateWallet, WalletCreatedResponse>
{
    private readonly IWalletRepository _walletRepository;

    public CreateWalletHandler(IWalletRepository walletRepository) => _walletRepository = walletRepository;

    public async Task<WalletCreatedResponse> HandleAsync(CreateWallet command, CancellationToken cancellationToken = default)
    {
        var isGivenNameAlreadyTaken = await _walletRepository.ExistAsync(command.Name, cancellationToken);

        if (isGivenNameAlreadyTaken) throw new WalletWithGivenNameAlreadyExistException();

        var wallet = Wallet.Create(WalletId.Create(),command.Name, WalletType.Private);

        await _walletRepository.AddAsync(wallet, cancellationToken);

        return new WalletCreatedResponse(wallet.Id);
    }
}
