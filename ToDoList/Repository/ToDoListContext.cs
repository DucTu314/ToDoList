using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class ToDoListContext : DbContext
    {
        public const string connectionString = @"Host=localhost;port=5432;Database=todolistdb;Username=newguest;Password=123";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(connectionString);
        }
        public DbSet<Day> days { get; set; }
        public DbSet<Task> tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Day>().HasKey(r => r.Id);
            modelBuilder
                  .Entity<Task>().HasKey(r => r.Id);
            modelBuilder
                .Entity<Task>()
                    .HasOne<Day>(s => s.Day)
                    .WithMany(g => g.ListTask)
                    .HasForeignKey(s => s.DayId);
                
        }

    }
}
