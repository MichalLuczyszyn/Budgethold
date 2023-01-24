namespace Budgethold.Shared.Infrastructure.Contexts
{
    using Abstractions.Contexts;

    internal interface IContextFactory
    {
        IContext Create();
    }
}