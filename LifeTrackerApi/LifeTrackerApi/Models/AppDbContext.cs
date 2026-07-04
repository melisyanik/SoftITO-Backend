using Microsoft.EntityFrameworkCore;
using LifeTrackerApi.Models;

namespace LifeTrackerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<MoodLog> MoodLogs { get; set; }
        public DbSet<HabitLog> HabitLogs { get; set; }
        public DbSet<SleepLog> SleepLogs { get; set; }
        public DbSet<ExpenseLog> ExpenseLogs { get; set; }
    }
}