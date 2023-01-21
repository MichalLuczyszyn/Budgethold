using Budgethold.Shared.Abstractions.Exceptions;

namespace Budgethold.Shared.Infrastructure.Exceptions;

internal interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}