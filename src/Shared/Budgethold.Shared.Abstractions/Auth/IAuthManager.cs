namespace Budgethold.Shared.Abstractions.Auth
{
    using System.Collections.Generic;

    public interface IAuthManager
    {
        JsonWebToken CreateToken(string userId, string role = null, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}