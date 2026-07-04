  using Microsoft.EntityFrameworkCore;
   using SmartLife.Models;

namespace SmartLife.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Notes> Notes { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Quotes> Quotes { get; set; }
    }
}