using DemoTestWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DemoTestWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Database=DemoTestWebAPI;UserId=postgres;Password=1121;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Themes>()
                .HasOne(themes => themes.Categories)
                .WithMany(category => category.Themes)
                .HasForeignKey(themes => themes.Category)
                .IsRequired();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Themes> Themes { get; set; }
    }
}
