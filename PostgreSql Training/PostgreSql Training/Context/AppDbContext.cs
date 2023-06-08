using Microsoft.EntityFrameworkCore;

namespace PostgreSql_Training.Context;

public class AppDbContext:DbContext
{
    public DbSet<User> Users => Set<User>();
   // public DbSet<UserNames> UserNames => Set<UserNames>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Database=kerak;User Id=postgres;Password=postgres;");
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserNames>().ToView("user_names");
    }*/
}