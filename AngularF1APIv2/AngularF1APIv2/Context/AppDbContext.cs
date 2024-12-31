using AngularF1APIv2.Models;
using Microsoft.EntityFrameworkCore;
namespace AngularF1APIv2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }  
        public DbSet<Post> Posts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Team)
                .WithMany(t  => t.Drivers)
                .HasForeignKey(d => d.TeamID);
        }
    }
}