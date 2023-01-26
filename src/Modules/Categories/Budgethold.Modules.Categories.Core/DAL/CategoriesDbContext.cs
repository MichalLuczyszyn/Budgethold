namespace Budgethold.Modules.Categories.Core.DAL;

using Entities;
using Microsoft.EntityFrameworkCore;

internal class CategoriesDbContext : DbContext
{
    public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("categories");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}