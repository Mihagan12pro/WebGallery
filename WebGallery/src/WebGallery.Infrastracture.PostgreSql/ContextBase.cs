using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebGallery.Infrastracture.PostgreSql
{
    public abstract class ContextBase : DbContext
    {
        public ILogger Logger { get; }

        protected readonly IConfiguration localConfiguration;
        protected readonly IConfiguration globalConfiguration;

        public string ConnectionStringRoot { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = localConfiguration.GetConnectionString(ConnectionStringRoot);

            optionsBuilder.UseNpgsql(connectionString);
        }

        public ContextBase(IConfiguration localConfiguration, IConfiguration globalConfiguration)
        {
            this.globalConfiguration = globalConfiguration;
            this.localConfiguration = localConfiguration.AddPostgresConfiguration();

            ConnectionStringRoot = this.GetType().Name;
        }
    }
}
