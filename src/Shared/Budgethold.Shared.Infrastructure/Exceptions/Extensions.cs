using Budgethold.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Budgethold.Shared.Infrastructure.Exceptions;

internal static class Extensions
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ErrorHandlerMiddleware>();
        serviceCollection.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
        serviceCollection.AddSingleton<IExceptionCompositionRoot, ExceptionCompositionRoot>();


        return serviceCollection;
    }

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        => app.UseMiddleware<ErrorHandlerMiddleware>();
}