namespace Budgethold.Modules.Users.Core.Exceptions
{
    using System;
    using Shared.Abstractions.Exceptions;

    internal class UserNotActiveException : BudgetholdException
    {
        public Guid UserId { get; }

        public UserNotActiveException(Guid userId) : base($"User with ID: '{userId}' is not active.")
        {
            UserId = userId;
        }
    }
}