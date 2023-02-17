namespace Budgethold.Shared.Abstractions.Commands;

using Messenger;

public interface ICommand : IMessage
{
    
}

public interface ICommand<TResult> : IMessage where TResult : class
{
}
