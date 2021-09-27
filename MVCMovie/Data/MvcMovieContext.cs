using Microsoft.EntityFrameworkCore;

public class MvcMovieContext : DbContext  // DbContext represents a database session
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MVCMovie.Models.Movie> Movie { get; set; }  // Dbset can be used to query and save instances of Movie class.
                                                                // 
    }
