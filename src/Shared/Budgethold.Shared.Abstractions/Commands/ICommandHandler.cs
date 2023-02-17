namespace Budgethold.Shared.Abstractions.Commands;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<in TCommand, TResult> where TCommand : class, ICommand<TResult> where TResult : class
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
