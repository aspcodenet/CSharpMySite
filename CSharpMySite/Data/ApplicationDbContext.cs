using Microsoft.EntityFrameworkCore;

namespace CSharpMySite.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }

}