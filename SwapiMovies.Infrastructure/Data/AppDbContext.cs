
using Microsoft.EntityFrameworkCore;
using SwapiMovies.Core.Entities;

namespace SwapiMovies.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) 
            : base (options)
        {
            
        }
        
        public DbSet<Rating> Ratings { get; set; }
    }
    
}