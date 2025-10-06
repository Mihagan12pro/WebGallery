using Microsoft.EntityFrameworkCore;
using WebGallery.Models.Statistics;

namespace WebGallery.Repositories.Contexts
{
    public class StatisticsContext : BaseContext
    {
        public DbSet<Page> Pages { get; set; } = null!;

        public DbSet<Visit> Visits { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().HasIndex(p => p.Path).IsUnique();
        }


        public StatisticsContext(IConfiguration configuration) : base(configuration, configuration["statistics:tittle"]!)
        {
          
        }
    }
}
