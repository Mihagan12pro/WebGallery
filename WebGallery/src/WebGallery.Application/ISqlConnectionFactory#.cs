using System.Data;

namespace WebGallery.Application;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}