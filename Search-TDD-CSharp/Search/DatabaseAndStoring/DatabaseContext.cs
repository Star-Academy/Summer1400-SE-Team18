using Microsoft.EntityFrameworkCore;
using Search.Models;

namespace Search.DatabaseAndStoring
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DataEntity> DataEntities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optins)
        {
            optins.UseSqlServer("Server=localhost;Database=FirstDatabase;Trusted_Connection=True;");
        }
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntity>()
                .HasKey(d => new { d.Word, d.FileName });
        }
    }
}