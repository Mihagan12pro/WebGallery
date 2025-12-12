using System.Text.Json.Serialization;
using Shared.Errors.Enums;

namespace Shared.Errors
{
    public record Error
    {
        public string Code { get; }

        public string Message { get; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorType Type { get; }

        public string? InvalidField { get; }

        public static Error None(string? code, string message)
            => new(code ?? "uknown.error", message, ErrorType.NONE);

        public static Error NotFound(string? code, string message, Guid? id = null)
            => new (code ?? "record.not.found", message, ErrorType.NOT_FOUND);

        public static Error Validation(string? code, string message, string? invalidField = null)
            => new(code ?? "value.is.invalid", message, ErrorType.VALIDATION, invalidField);

        public static Error Conflict(string? code, string message, string? invalidField = null)
            => new(code ?? "value.is.conflict", message, ErrorType.CONFLICT, invalidField);

        public static Error Failure(string? code, string message)
            => new(code ?? "failure", message, ErrorType.FAILURE);

        public Failure ToCollection() => this;

        [JsonConstructor]
        private Error(string code, string message, ErrorType type, string? invalidField = null)
        {
            Code = code;
            Message = message;
            Type = type;
            InvalidField = invalidField;
        }
    }
}
