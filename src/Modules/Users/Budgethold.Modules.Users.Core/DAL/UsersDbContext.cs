namespace Budgethold.Modules.Users.Core.DAL
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    internal class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("users");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}