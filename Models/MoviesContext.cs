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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    Category = "Comedy",
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
                    Category = "Family",
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
                    Category = "Action/Adventure",
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
