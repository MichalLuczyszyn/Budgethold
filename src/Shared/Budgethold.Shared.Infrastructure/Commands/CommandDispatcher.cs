namespace Budgethold.Shared.Infrastructure.Commands;

using Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

internal sealed class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
    
    public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : class, ICommand
    {
        if (command is null) return;

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<TResult> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken) where TCommand : class, ICommand<TResult> where TResult : class
    {
        if (command is null) throw new InvalidOperationException("Command not found");

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();

       return await handler.HandleAsync(command, cancellationToken);
    }
}
