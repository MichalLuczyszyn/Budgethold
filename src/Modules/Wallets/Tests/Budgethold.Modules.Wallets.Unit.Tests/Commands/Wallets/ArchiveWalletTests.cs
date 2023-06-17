namespace Budgethold.Modules.Wallets.Unit.Tests.Commands.Wallets;

using Core.Commands.Wallets.Archive;
using Core.Exceptions;
using Domain.Wallets.Entities;
using Domain.Wallets.Repositories;
using Domain.Wallets.ValueObjects;
using FluentAssertions;
using NSubstitute;
using Shared.Abstractions;
using UnitTests.Common.Fakers;
using Xunit;

public class ArchiveWalletTests
{
    private readonly IWalletRepository _walletRepository = Substitute.For<IWalletRepository>();
    private readonly IClock _clock = Substitute.For<IClock>();
    private readonly ArchiveWalletHandler _handler;
    private readonly ArchiveWallet _command;
    private readonly CancellationToken _cancellationToken;
    private readonly Guid _walletId = Guid.NewGuid();

    public ArchiveWalletTests()
    {
        _handler = new ArchiveWalletHandler(_walletRepository, _clock);
        _command = new ArchiveWallet(_walletId);
        _cancellationToken = CancellationToken.None;
        _clock.CurrentDateTimeOffset().Returns(DateTimeOffset.UtcNow);
    }

    [Fact]
    public async Task GIVEN_ArchiveWallet_WHEN_WalletExists_THEN_ShouldArchiveWallet()
    {
        // Arrange
        var wallet = PrepareWallet();
        _walletRepository.GetAsync(_command.Id, _cancellationToken).Returns(wallet);

        // Act
        await _handler.HandleAsync(_command, _cancellationToken);

        // Assert
        await _walletRepository.Received(1).GetAsync(_command.Id, _cancellationToken);
        await _walletRepository.Received(1)
            .SaveChangeAsync(Arg.Is<Wallet>(w => w.Id == _walletId), _cancellationToken);
    }

    private Wallet PrepareWallet()
    {
        var wallet = Wallet.Create(_walletId, NameFaker.Name(), WalletType.Shared);
        return wallet;
    }

    [Fact]
    public async Task GIVEN_ArchiveWallet_WHEN_WalletNotFound_THEN_ShouldThrowWalletWasNotFoundException()
    {
        // Arrange
        _walletRepository.GetAsync(_command.Id, _cancellationToken).Returns((Wallet)null);

        // Act
        var act = async () => await _handler.HandleAsync(_command, _cancellationToken);

        // Assert
        await act.Should().ThrowAsync<WalletWasNotFoundException>();
    }
}
