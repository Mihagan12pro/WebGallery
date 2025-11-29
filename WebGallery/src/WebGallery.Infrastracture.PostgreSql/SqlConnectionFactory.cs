using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using WebGallery.Application.Database;

namespace WebGallery.Infrastracture.PostgreSql;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;
    
    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));

        return connection;
    }

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
}