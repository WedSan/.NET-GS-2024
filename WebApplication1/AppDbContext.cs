using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1;

public class AppDbContext : DbContext
{
    public DbSet<User?> Users { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}