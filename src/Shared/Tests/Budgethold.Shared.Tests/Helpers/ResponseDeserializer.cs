namespace Budgethold.Shared.Tests.Helpers;

using System.Text.Json;

public static class ResponseDeserializer
{
    private static JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    public static async Task<Guid> GuidDeserializer(HttpResponseMessage responseMessage)
    {
        var responseContent = await responseMessage.Content.ReadAsStringAsync();
        var guidResponse = JsonSerializer.Deserialize<GuidResponse>(responseContent, _options);

        if (guidResponse is null) throw new InvalidDataException();

        return guidResponse.Id;
    }
    
    public static async Task<T?> GetDeserializedResponse<T>(HttpResponseMessage response) where T : class
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<T>(responseContent, _options);

        if (deserializedResponse is null)
        {
            throw new InvalidDataException();
        }

        return deserializedResponse;
    }
}
public class GuidResponse
{
    public Guid Id { get; set; }
}
