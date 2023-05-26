namespace Budgethold.Frontend.Shared.Shared.Http;

using System.Net;
using AntDesign;

public interface IApiResponseHandler
{
    Task<ApiResponse> HandleAsync(Task<ApiResponse> request);
    Task<T> HandleAsync<T>(Task<ApiResponse<T>> request);
}

public class ApiResponseHandler : IApiResponseHandler
{
    private const int ModalDurationSeconds = 1;
    private readonly MessageService _messageService;

    public ApiResponseHandler(MessageService messageService) => _messageService = messageService;

    public async Task<ApiResponse> HandleAsync(Task<ApiResponse> request)
    {
        var response = await request;
        if (response.Succeeded)
        {
            return response;
        }

        await HandleErrorAsync(response);
        return default;
    }

    public async Task<T> HandleAsync<T>(Task<ApiResponse<T>> request)
    {
        var response = await request;
        if (response.Succeeded)
        {
            return response.Value;
        }

        await HandleErrorAsync(response);
        return default;
    }

    private async Task HandleErrorAsync(ApiResponse response)
    {
        if (response?.HttpResponse is null)
        {
            await _messageService.Error("There was an error.");
            return;
        }
        
        if (response.HttpResponse.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _messageService.Error("Your session has expired - please sign in again.");
            return;
        }

        if (response.Error is {})
        {
            await _messageService.Error(response.Error.Reason, ModalDurationSeconds);
        }
    }
}
