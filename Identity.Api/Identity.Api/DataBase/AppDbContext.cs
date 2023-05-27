using Identity.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.DataBase;

public class AppDbContext:DbContext
{
    public DbSet<User> Users => Set<User>();
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users1");

            entity.HasKey(x => x.Id);

            entity.HasIndex(e => e.Username).IsUnique();
        });
    }
}