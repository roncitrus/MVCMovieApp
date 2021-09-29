using Microsoft.EntityFrameworkCore;
using MVCMovie.Models.ModelConfigurations;

public class MvcMovieContext : DbContext  // DbContext represents a database session
{
    public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.UseSerialColumns();
        builder.ApplyConfiguration(new MovieConfiguration());
    }

   public DbSet<MVCMovie.Models.Movie> Movie { get; set; }  // Dbset can be used to query and save instances of Movie class.
}
