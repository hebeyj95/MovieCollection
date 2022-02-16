using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaconsaleMovieCollection.Models
{
    public class MoviesContext : DbContext
    {
        //Constructor
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
            //leave blank for now
        }
        public DbSet<ApplicationResponse> responses { get; set; }

        public DbSet<Category> categories { get; set; }

        //seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
                );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryID = 2,
                    Title = "Hitch",
                    Year = 2005,
                    Director = "Andy Tennant",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryID = 4,
                    Title = "Toy Story",
                    Year = 1995,
                    Director = "John Lasseter",
                    Rating = "G",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryID = 1,
                    Title = "Spider-Man",
                    Year = 2002,
                    Director = "Sam Raimi",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                }
            );
        }
    }
}
