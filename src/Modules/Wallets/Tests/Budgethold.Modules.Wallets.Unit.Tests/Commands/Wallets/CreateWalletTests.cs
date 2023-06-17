namespace Budgethold.Modules.Wallets.Unit.Tests.Commands.Wallets;

using Core.Commands.Wallets.Create;
using Core.Exceptions;
using Domain.Wallets.Entities;
using Domain.Wallets.Repositories;
using FluentAssertions;
using NSubstitute;
using UnitTests.Common.Fakers;
using Xunit;

public class CreateWalletTests
{
    private readonly IWalletRepository _walletRepository = Substitute.For<IWalletRepository>();
    private readonly CreateWalletHandler _handler;
    private readonly CreateWallet _command;
    private readonly CancellationToken _cancellationToken;
    private readonly string _walletName = NameFaker.Name();

    public CreateWalletTests()
    {
        _handler = new CreateWalletHandler(_walletRepository);
        _command = new CreateWallet(_walletName);
        _cancellationToken = CancellationToken.None;
    }

    [Fact]
    public async Task GIVEN_CreateWallet_WHEN_NameIsFree_THEN_ShouldCreateWalletAndReturnResponse()
    {
        // Arrange
        _walletRepository.ExistAsync(_walletName, _cancellationToken).Returns(Task.FromResult(false));

        // Act
        var response = await _handler.HandleAsync(_command, _cancellationToken);
        
        // Assert
        await _walletRepository.Received(1).ExistAsync(_walletName, _cancellationToken);
        await _walletRepository.Received(1).AddAsync(Arg.Is<Wallet>(w => w.Name == _walletName), _cancellationToken);
    }
    
    [Fact]
    public async Task GIVEN_CreateWallet_WHEN_NameIsTaken_THEN_ShouldThowWalletWithGivenNameAlreadyExistException()
    {
        // Arrange
        _walletRepository.ExistAsync(_walletName, _cancellationToken).Returns(Task.FromResult(true));
        
        // Act
        Func<Task> act = async () => await _handler.HandleAsync(_command, _cancellationToken);
        
        // Assert
        await act.Should().ThrowAsync<WalletWithGivenNameAlreadyExistException>();
    }
}
