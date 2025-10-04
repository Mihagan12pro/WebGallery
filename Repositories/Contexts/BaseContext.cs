using Microsoft.EntityFrameworkCore;

namespace WebGallery.Repositories.Contexts
{
    public abstract class BaseContext : DbContext
    {
        private readonly ConfigurationBuilder? postgreConfigurationBuilder = new ConfigurationBuilder();

        private readonly IConfigurationRoot? postgreConfigurationRoot;

        private readonly string ?password;

        private readonly string ?port;

        private readonly string ?username;

        private readonly string ?host;

        public string? DatabaseName { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={host};Port={port};Database={DatabaseName};Username={username};Password={password}");
        }


        public BaseContext()
        {
            postgreConfigurationBuilder.AddJsonFile("postgresConfig.json");

            postgreConfigurationRoot = postgreConfigurationBuilder.Build();

            password = postgreConfigurationRoot.GetConnectionString(nameof(password));
            port = postgreConfigurationRoot.GetConnectionString(nameof(port));
            username = postgreConfigurationRoot.GetConnectionString(nameof(username));
            host = postgreConfigurationRoot.GetConnectionString(nameof(host));
        }
    }
}
