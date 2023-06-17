namespace Budgethold.Modules.Wallets.Unit.Tests.Commands.Wallets;

using Core.Commands.Wallets.Update;
using Core.Exceptions;
using Domain.Wallets.Entities;
using Domain.Wallets.Repositories;
using Domain.Wallets.ValueObjects;
using FluentAssertions;
using NSubstitute;
using UnitTests.Common.Fakers;
using Xunit;

public class UpdateWalletTests
{
    private readonly IWalletRepository _walletRepository = Substitute.For<IWalletRepository>();
    private readonly UpdateWalletHandler _handler;
    private readonly UpdateWallet _command;
    private readonly CancellationToken _cancellationToken;
    private readonly Guid _walletId = Guid.NewGuid();
    private readonly string _walletName = NameFaker.Name();

    public UpdateWalletTests()
    {
        _handler = new UpdateWalletHandler(_walletRepository);
        _command = new UpdateWallet(_walletId, _walletName);
        _cancellationToken = CancellationToken.None;
    }

    [Fact]
    public async Task GIVEN_UpdateWallet_WHEN_NameIsFree_THEN_ShouldUpdateWallet()
    {
        // Arrange
        _walletRepository.ExistAsync(_command.Name, _cancellationToken).Returns(Task.FromResult(false));
        _walletRepository.GetAsync(_command.Id, _cancellationToken)
            .Returns(Wallet.Create(_command.Id, _walletName, WalletType.Private));

        // Act
        await _handler.HandleAsync(_command, _cancellationToken);

        // Assert
        await _walletRepository.Received(1).ExistAsync(_command.Name, _cancellationToken);
        await _walletRepository.Received(1).GetAsync(_command.Id, _cancellationToken);
        await _walletRepository.Received(1)
            .SaveChangeAsync(Arg.Is<Wallet>(w => w.Name == _command.Name), _cancellationToken);
    }

    [Fact]
    public async Task GIVEN_UpdateWallet_WHEN_NameIsTaken_THEN_ShouldThrowWalletWithGivenNameAlreadyExistException()
    {
        // Arrange
        _walletRepository.ExistAsync(_command.Name, _cancellationToken).Returns(Task.FromResult(true));

        // Act
        var act = async () => await _handler.HandleAsync(_command, _cancellationToken);

        // Assert
        await act.Should().ThrowAsync<WalletWithGivenNameAlreadyExistException>();
    }

    [Fact]
    public async Task GIVEN_UpdateWallet_WHEN_WalletNotFound_THEN_ShouldThrowWalletWasNotFoundException()
    {
        // Arrange
        _walletRepository.ExistAsync(_command.Name, _cancellationToken).Returns(false);
        _walletRepository.GetAsync(_command.Id, _cancellationToken).Returns((Wallet)null);

        // Act
        var act = async () => await _handler.HandleAsync(_command, _cancellationToken);

        // Assert
        await act.Should().ThrowAsync<WalletWasNotFoundException>();
    }
}
