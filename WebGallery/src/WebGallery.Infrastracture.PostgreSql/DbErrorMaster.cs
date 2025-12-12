using Shared.Errors;

namespace WebGallery.Infrastracture.PostgreSql
{
    internal static class DbErrorMaster
    {
        public static Error GetUniqueConstaitError(string message, string? invalidField = null)
            => Error.Conflict(null, message, invalidField);
    }
}
