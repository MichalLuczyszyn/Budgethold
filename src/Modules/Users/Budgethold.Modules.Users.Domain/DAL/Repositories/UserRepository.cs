namespace Budgethold.Modules.Users.Core.DAL.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Core.Repositories;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    internal class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
            _users = _context.Users;
        }

        public Task<User?> GetAsync(Guid id) => _users.SingleOrDefaultAsync(x => x.Id == id);
        
        public Task<User?> GetAsync(string email) => _users.SingleOrDefaultAsync(x => x.Email == email);

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}