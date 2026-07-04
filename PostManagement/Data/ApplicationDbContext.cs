using Microsoft.EntityFrameworkCore;
using SocialManagement.Models;

namespace SocialManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
    }
}