using Microsoft.EntityFrameworkCore;
using Search.Models;

namespace Search.DatabaseAndStoring
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Data> Data { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optins)
        {
            optins.UseSqlServer("Server=localhost;Database=FirstDatabase;Trusted_Connection=True;");
        }
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>()
                .HasKey(c => new { c.Word });
        }
    }
}