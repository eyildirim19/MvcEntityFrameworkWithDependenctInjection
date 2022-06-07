using Microsoft.EntityFrameworkCore;

namespace MvcEntityFrameworkWithDependenctInjection.Models
{
    public class AppDbContext : DbContext
    {   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\mssqlexpress; Database=Northwind; uid=sa;pwd=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("CategoryID");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("CategoryName");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
