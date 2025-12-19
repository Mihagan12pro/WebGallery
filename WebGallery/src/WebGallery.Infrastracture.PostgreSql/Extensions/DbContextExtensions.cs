using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shared.Errors;

namespace WebGallery.Infrastracture.PostgreSql.Extensions
{
    internal static class DbContextExtensions
    {
        public static async Task<UnitResult<Error>> CheckUniqueConstrait<TEntity>(
            this DbContext context,
            TEntity entity,
            string columnTitle,
            object columnValue,
            string message)

            where TEntity : class
        {
            Type contextType = context.GetType();

            PropertyInfo? dbSet = contextType.
                GetProperties().
                    Select(p => p).
                        FirstOrDefault(p => p.PropertyType == typeof(DbSet<TEntity>));

            if (dbSet == null)
            {
                Error error = Error.Failure(null, $"There is no record called '{typeof(TEntity).Name}s'");

                return error;
            }

            Type entityType = entity.GetType();

            PropertyInfo? entityProperty = entityType.
                GetProperties().
                    FirstOrDefault(p => p.Name == columnTitle);

            if (entityProperty == null)
            {
                Error error = Error.Failure(null, $"{typeof(TEntity).Name} does not contains property called'{columnTitle}'");

                return error;
            }

            DbSet<TEntity>? set = dbSet.GetValue(context) as DbSet<TEntity>;

            var entityParameterExpression = Expression.Parameter(typeof(TEntity));

            var entityPropertyExpression = Expression.Property(entityParameterExpression, entityProperty);

            var constantExpression = Expression.Constant(columnValue, entityProperty.PropertyType);

            var equalExpression = Expression.Equal(entityPropertyExpression, constantExpression);

            var lambdaExpression = Expression.Lambda<Func<TEntity, bool>>(equalExpression, entityParameterExpression);

            var result = await set!.FirstOrDefaultAsync(lambdaExpression);

            if (result == null)
                return UnitResult.Success<Error>();

            return Error.Conflict(null, message);
        }
    }
}
