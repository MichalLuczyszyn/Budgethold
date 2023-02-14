namespace Budgethold.Modules.Users.Core.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    internal interface IUserRepository
    {
        Task<User?> GetAsync(Guid id);
        Task<User?> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}