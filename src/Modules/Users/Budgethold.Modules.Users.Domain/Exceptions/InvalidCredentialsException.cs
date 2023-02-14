namespace Budgethold.Modules.Users.Core.Exceptions
{
    using Shared.Abstractions.Exceptions;

    internal class InvalidCredentialsException : BudgetholdException
    {
        public InvalidCredentialsException() : base("Invalid credentials.")
        {
        }
    }
}