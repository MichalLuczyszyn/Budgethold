﻿namespace Budgethold.Frontend.Shared.Shared.Http;

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

public interface IHttpClient
{
    Task<ApiResponse<T>> GetAsync<T>(string endpoint);
    Task<ApiResponse> PostAsync(string endpoint, object request);
    Task<ApiResponse<T>> PostAsync<T>(string endpoint, object request);
    Task<ApiResponse> PutAsync(string endpoint, object request);
    Task<ApiResponse> DeleteAsync(string endpoint);
}

public sealed class CustomHttpClient : IHttpClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase, Converters = { new JsonStringEnumConverter() }
    };

    private readonly IHttpClientFactory _client;
    private readonly ILogger<CustomHttpClient> _logger;

    public CustomHttpClient(IHttpClientFactory client,
        ILogger<CustomHttpClient> logger)
    {
        _client = client;
        _logger = logger;
    }

    public Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        => TryRequestAsync<T>(new HttpRequestMessage(HttpMethod.Get, endpoint));

    public async Task<ApiResponse> PostAsync(string endpoint, object request)
    {
        var response = await TryRequestAsync<object>(new HttpRequestMessage(HttpMethod.Post, endpoint) { Content = GetPayload(request) });

        return response;
    }

    public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object request)
    {
        var response = await TryRequestAsync<T>(new HttpRequestMessage(HttpMethod.Post, endpoint) { Content = GetPayload(request) });

        return response;
    }

    public async Task<ApiResponse> PutAsync(string endpoint, object request)
    {
        var response = await TryRequestAsync<object>(new HttpRequestMessage(HttpMethod.Put, endpoint) { Content = GetPayload(request) });

        return response;
    }

    public async Task<ApiResponse> DeleteAsync(string endpoint)
    {
        var response = await TryRequestAsync<object>(new HttpRequestMessage(HttpMethod.Delete, endpoint));

        return response;
    }

    private static StringContent GetPayload<T>(T request)
        => new(JsonSerializer.Serialize(request, SerializerOptions), Encoding.UTF8, "application/json");

    private async Task<ApiResponse<T>> TryRequestAsync<T>(HttpRequestMessage request)
    {
        HttpResponseMessage response = null;
        try
        {
            var requestId = Guid.NewGuid().ToString("N");
            _logger.LogInformation($"Sending HTTP request [ID: {requestId}]...");
            
            var httpClient = _client.CreateClient("BudgetholdAPI");
            response = await httpClient.SendAsync(request);
            var isValid = response.IsSuccessStatusCode;
            var responseStatus = isValid ? "valid" : "invalid";
            _logger.LogInformation($"Received the {responseStatus} response [ID: {requestId}].");
            var payload = await response.Content.ReadAsStringAsync();
            if (!isValid)
            {
                _logger.LogError(response.ToString());
                _logger.LogError(payload);

                if (!payload.Contains("code"))
                {
                    return new ApiResponse<T>(default, response, false, new ApiResponse.ErrorResponse { Code = "error", Reason = payload });
                }

                var error = string.IsNullOrWhiteSpace(payload)
                    ? default
                    : JsonSerializer.Deserialize<ApiResponse.ErrorResponse>(payload, SerializerOptions);

                return new ApiResponse<T>(default, response, false, error);
            }

            var result = string.IsNullOrWhiteSpace(payload)
                ? default
                : JsonSerializer.Deserialize<T>(payload, SerializerOptions);

            return new ApiResponse<T>(result, response, true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ApiResponse<T>(default, response, false);
        }
    }
}
