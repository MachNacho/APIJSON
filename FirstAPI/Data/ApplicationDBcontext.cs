using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the application's database context, managing entity configurations and database operations.
/// Inherits from <see cref="DbContext"/> to enable Entity Framework Core functionality.
/// </summary>
public class ApplicationDBContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDBContext"/> class.
    /// </summary>
    /// <param name="dbContextOptions">The database context options used to configure the context.</param>
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    /// <summary>
    /// DbSet properties represent tables in the database.
    /// Add entities as needed.
    /// </summary>
    // public DbSet<MyEntity> MyEntities { get; set; }
}
