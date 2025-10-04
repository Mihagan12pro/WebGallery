using Microsoft.EntityFrameworkCore;
using WebGallery.Models.Statistics;

namespace WebGallery.Repositories.Contects
{
    public class StatisticsContext : DbContext
    {
        public DbSet<Page> Pages { get; set; } = null!;

        public DbSet<Visit> Visits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=3306;Database=statistics_db;Username=postgres;Password=123456789");
        }
    }
}
