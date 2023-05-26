namespace Budgethold.Frontend.Shared.Wallets.Services;

using Requests;
using Responses;
using Shared;
using Shared.Http;

public interface IWalletsService
{
    Task<ApiResponse<ICollection<GetWalletsResponse>>> BrowseAsync();
    Task<ApiResponse<GetWalletResponse>> GetAsync(Guid id);
    Task<ApiResponse> CreateAsync(CreateWalletRequest request);
    Task<ApiResponse> DeleteAsync(Guid id);
    Task<ApiResponse> UpdateAsync(Guid id, UpdateWalletRequest updateWalletRequest);
}

public class WalletsService : IWalletsService
{
    private readonly IHttpClient _httpClient;
    private static readonly string BaseUrl = Consts.WalletsModule + "/" + Consts.Wallets;

    public WalletsService(IHttpClient httpClient) => _httpClient = httpClient;

    public Task<ApiResponse<ICollection<GetWalletsResponse>>> BrowseAsync() => _httpClient.GetAsync<ICollection<GetWalletsResponse>>(BaseUrl);

    public Task<ApiResponse<GetWalletResponse>> GetAsync(Guid id) => _httpClient.GetAsync<GetWalletResponse>(BaseUrlWithId(id));

    public Task<ApiResponse> CreateAsync(CreateWalletRequest request) => _httpClient.PostAsync(BaseUrl, request);

    public Task<ApiResponse> DeleteAsync(Guid id) => _httpClient.DeleteAsync(BaseUrlWithId(id));

    public Task<ApiResponse> UpdateAsync(Guid id, UpdateWalletRequest updateWalletRequest) => _httpClient.PostAsync(BaseUrlWithId(id), updateWalletRequest);

    private static string BaseUrlWithId(Guid id) => BaseUrl + "/" + id;
}
