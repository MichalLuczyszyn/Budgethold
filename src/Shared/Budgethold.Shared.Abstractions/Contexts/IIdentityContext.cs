namespace Budgethold.Shared.Abstractions.Contexts
{
    using System;
    using System.Collections.Generic;

    public interface IIdentityContext
    {
        bool IsAuthenticated { get; }
        public Guid Id { get; }
        string Role { get; }
        Dictionary<string, IEnumerable<string>> Claims { get; }
    }
}