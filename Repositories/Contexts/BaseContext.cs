using Microsoft.EntityFrameworkCore;

namespace WebGallery.Repositories.Contexts
{
    public abstract class BaseContext : DbContext
    {
        private string? _password;

        private string? _port;

        private string? _username;

        private string? _host;
        private string? _databaseName { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={_host};Port={_port};Database={_databaseName};Username={_username};Password={_password}");
        }


        public BaseContext(IConfiguration configuration, string databaseName)
        {
            _host = configuration["postgres:host"];
            
            _port = configuration["postgres:port"];
            
            _username = configuration["postgres:username"];

            _password = configuration["postgres:password"];

            this._databaseName = databaseName;

            Database.EnsureCreated();
        }
    }
}
