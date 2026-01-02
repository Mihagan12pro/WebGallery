using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebGallery.Infrastracture.PostgreSql
{
    public abstract class ContextBase : DbContext
    {
        public ILogger Logger { get; }

        private readonly IConfiguration _configuration;

        public string ConnectionStringRoot { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = _configuration.GetConnectionString(ConnectionStringRoot);

            optionsBuilder.UseNpgsql(connectionString);
        }

        public ContextBase(IConfiguration configuration)
        {
            _configuration = configuration.AddPostgresConfiguration();

            ConnectionStringRoot = this.GetType().Name;

            Database.EnsureCreated();
        }
    }
}
