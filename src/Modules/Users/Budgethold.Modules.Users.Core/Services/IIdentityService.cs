namespace Budgethold.Modules.Users.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using DTO;
    using Shared.Abstractions.Auth;

    public interface IIdentityService
    {
        Task<AccountDto> GetAsync(Guid id);
        Task<JsonWebToken> SignInAsync(SignInDto dto);
        Task SignUpAsync(SignUpDto dto);
    }
}