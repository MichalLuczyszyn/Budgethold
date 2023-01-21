using System.Net;
using Budgethold.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Budgethold.Shared.Infrastructure.Exceptions;

internal class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly IExceptionCompositionRoot _exceptionToResponseMapper;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, IExceptionCompositionRoot exceptionToResponseMapper)
    {
        _logger = logger;
        _exceptionToResponseMapper = exceptionToResponseMapper;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleErrorAsync(context, e);
        }
    }

    private async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var errorResponse = _exceptionToResponseMapper.Map(exception);
        context.Response.StatusCode = (int)(errorResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
        var response = errorResponse?.Response;
        if (response is null)
        {
            return;
        }

        await context.Response.WriteAsJsonAsync(response);
    }
}