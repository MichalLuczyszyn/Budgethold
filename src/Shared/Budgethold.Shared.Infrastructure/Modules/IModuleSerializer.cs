namespace Budgethold.Shared.Infrastructure.Modules;

public interface IModuleSerializer
{
    byte[] Serialize<T>(T value);
    object Deserialize<T>(byte[] value);
    object Deserialize(byte[] value, Type type);
}
