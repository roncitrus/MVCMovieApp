using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MVCMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<     // GetRequiredService returns an object of type serviceType, or throws an exception.
                DbContextOptions<MvcMovieContext>>()))
            {
                // look for any movies.
                if (context.Movie.Any())
                {
                    return; // DB has already been seeded.
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Big Lebowski",
                        ReleaseDate = DateTime.Parse("1998-5-1"),
                        Genre = "Comedy",
                        Price = 7.99M,
                        Rating = "18"
                    },

                    new Movie
                    {
                        Title = "Brazil",
                        ReleaseDate = DateTime.Parse("1985-2-22"),
                        Genre = "Sci-Fi Drama",
                        Price = 6.99M,
                        Rating = "15"
                    },

                    new Movie
                    {
                        Title = "12 Monkeys",
                        ReleaseDate = DateTime.Parse("1996-4-19"),
                        Genre = "Sci-Fi Drama",
                        Price = 6.49M,
                        Rating = "15"
                    },

                    new Movie
                    {
                        Title = "The Shining",
                        ReleaseDate = DateTime.Parse("1980-2-10"),
                        Genre = "Horror",
                        Price = 3.99M,
                        Rating= "18"
                    },

                    new Movie
                    {
                        Title = "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb",
                        ReleaseDate = DateTime.Parse("1964-1-29"),
                        Genre = "Comedy",
                        Price = 4.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "THX 1138",
                        ReleaseDate = DateTime.Parse("1971-6-1"),
                        Genre = "Sci-Fi Drama",
                        Price = 1.99M,
                        Rating = "15"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
