using System.Collections.Concurrent;
using System.Net;
using Budgethold.Shared.Abstractions.Exceptions;
using Humanizer;

namespace Budgethold.Shared.Infrastructure.Exceptions;

internal class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();

    public ExceptionResponse Map(Exception exception)
        => exception switch
        {
            BudgetholdException ex => new ExceptionResponse(new ErrorsResponse(HttpStatusCode.BadRequest,new Error(GetErrorCode(ex), ex.Message)), HttpStatusCode.BadRequest)
        };

    private record Error(string Code, string Message);

    private record ErrorsResponse(HttpStatusCode StatusCode, params Error[] Errors);

    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        var code = type.Name.Underscore().Replace("_exception", string.Empty);

        return Codes.GetOrAdd(type, code);
    }
}