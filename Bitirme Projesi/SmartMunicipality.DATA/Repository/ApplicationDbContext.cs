using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.MODEL;

using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.DATA.Repository;

namespace SmartMunicipality.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Bill>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            builder.Entity<Payment>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            builder.Entity<ConsumptionRecord>()
                .Property(x => x.ConsumptionValue)
                .HasPrecision(18, 2);

            builder.Entity<ComplaintResponse>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<ComplaintCategory> ComplaintCategories { get; set; }

        public DbSet<ComplaintStatus> ComplaintStatuses { get; set; }

        public DbSet<Complaint> Complaints { get; set; }

        public DbSet<ComplaintResponse> ComplaintResponses { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<ConsumptionRecord> ConsumptionRecords { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<AIAlert> AIAlerts { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}