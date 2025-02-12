using Microsoft.EntityFrameworkCore;

namespace Mission06_Rindlisbacher.Models
{
    public class MovieContext : DbContext // Tell it it's a dbcontext file
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } // Call the movie class and create a database with those objects
    }
}
