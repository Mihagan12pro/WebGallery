using System.Data;

namespace WebGallery.Application.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
