namespace Budgethold.Shared.Tests.Context;

using Abstractions.Contexts;

public class FakeContext : IContext
{
    public FakeContext(IIdentityContext identity)
    {
        Identity = identity;
    }

    public string RequestId { get; } = Guid.NewGuid().ToString();
    public string TraceId { get; }
    public IIdentityContext Identity { get; }
}