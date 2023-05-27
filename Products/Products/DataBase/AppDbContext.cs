using Microsoft.EntityFrameworkCore;
using Products.Entities;

namespace Products.DataBase;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;" +
                                    " Database=products_; User Id = products_; Password=asd12345;TrustServerCertificate=True");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}