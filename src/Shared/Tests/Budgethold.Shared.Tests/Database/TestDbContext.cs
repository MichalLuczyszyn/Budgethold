namespace Budgethold.Shared.Tests.Database;

using Microsoft.EntityFrameworkCore;

public abstract class TestDbContext<T> where T : DbContext, IDisposable
{
    public T Context { get; }

    protected TestDbContext(string connectionString = null)
    {
        Context = Init(connectionString);
            
        if (Context is null)
        {
            throw new InvalidOperationException($"DB context for {typeof(T)} was not initialized.");
        }
    }

    protected abstract T Init(string connectionString);

    public void Dispose()
    {
        Context?.Database.EnsureDeleted();
        Context?.Dispose();
    }
}
