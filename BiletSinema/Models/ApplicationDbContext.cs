using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BiletSinema.Models;

namespace BiletSinema.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Filmler> Filmler { get; set; }

        public DbSet<Diziler> Diziler { get; set; }

        public DbSet<Tiyatrolar> Tiyatrolar { get; set; }

        public DbSet<Kategori> Kategori { get; set; }
    }
}