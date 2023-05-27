using Microsoft.EntityFrameworkCore;
using ShoppingMall.Entities;

namespace ShoppingMall.DataBase;

public class AppDbContext:DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;" +
                                    " Database=educations_; User Id = educations_; Password=asd12345;TrustServerCertificate=True");
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}