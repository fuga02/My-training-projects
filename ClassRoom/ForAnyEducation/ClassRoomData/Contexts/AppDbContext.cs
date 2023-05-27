using ClassRoomData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomData.Contexts;

public class AppDbContext:IdentityDbContext<User,IdentityRole<Guid>,Guid>
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        builder.Entity<User>().ToTable("users");
        builder.Entity<User>()
            .Property(u => u.FirstName)
            .HasMaxLength(50)
            .HasColumnName("firstname")
            .IsRequired(false);
        builder.Entity<User>()
            .Property(u => u.LastName)
            .HasMaxLength(50)
            .HasColumnName("lastname")
            .IsRequired(false);
        builder.Entity<User>()
            .Property(u => u.PhotoUrl)
            .HasColumnName("photo_url")
            .IsRequired(true);
    }
    public DbSet<School> Schools { get; set; }
    public DbSet<UserSchool> UserSchools { get; set; }

}