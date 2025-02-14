using FirstAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the application's database context, managing entity configurations and database operations.
/// Inherits from <see cref="IdentityDbContext"/> to enable Entity Framework Core functionality.
/// </summary>
public class ApplicationDBContext : IdentityDbContext<User>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDBContext"/> class.
    /// </summary>
    /// <param name="dbContextOptions">The database context options used to configure the context.</param>
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                   new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER",
                }
            };
        builder.Entity<IdentityRole>().HasData(roles);
    }

    /// <summary>
    /// DbSet properties represent tables in the database.
    /// Add entities as needed.
    /// </summary>
    public DbSet<Achivement> achivements { get; set; }
     public DbSet<Education> educations { get; set; }
     public DbSet<Experience> experiences { get; set; }
     public DbSet<Hobby> hobbies { get; set; }
     public DbSet<Project>  projects{ get; set; }
}
