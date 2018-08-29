using Hackathon.Model;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GoalType> GoalTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<GoalSubscriber> GoalSubscribers { get; set; }
        public DbSet<UserGoal> UserGoals { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public SQLLiteContext(DbContextOptions<SQLLiteContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hackathon.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DataSeeder.SeedUsers(builder);
            DataSeeder.SeedGoalTypes(builder);
            DataSeeder.SeedUserGoals(builder);
            DataSeeder.SeedGoalSubscribers(builder);
            DataSeeder.SeedNotifications(builder);
        }
    }
}
