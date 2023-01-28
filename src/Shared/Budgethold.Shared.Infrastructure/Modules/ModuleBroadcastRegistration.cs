namespace Budgethold.Shared.Infrastructure.Modules;

public sealed class ModuleBroadcastRegistration
{
    public ModuleBroadcastRegistration(Type receiverType, Func<object, Task> action)
    {
        ReceiverType = receiverType;
        Action = action;
    }
    public Type ReceiverType { get; }
    public Func<object, Task> Action { get; }
    public string Key => ReceiverType.Name;
}
