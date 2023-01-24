namespace Budgethold.Modules.Users.Core.Exceptions
{
    using Shared.Abstractions.Exceptions;

    internal class EmailInUseException : BudgetholdException
    {
        public EmailInUseException() : base("Email is already in use.")
        {
        }
    }
}