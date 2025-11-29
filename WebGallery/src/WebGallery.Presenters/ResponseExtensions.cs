using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Errors;
using Shared.Errors.Enums;

namespace WebGallery.Presenters
{
    internal static class ResponseExtensions
    {
        public static ActionResult ToErrorResponse(this Failure failure)
        {
            if (!failure.Any())
            {
                return new ObjectResult(null)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            var distinctErrorTypes = failure.
                Select(x => x.Type).
                    Distinct().
                        ToList();

            int statusCode = MapErrorTypesAndStatusCodes(distinctErrorTypes.First());

            if (distinctErrorTypes.Count() > 1)
               statusCode = StatusCodes.Status500InternalServerError;

            return new ObjectResult(failure)
            {
                StatusCode = statusCode,
            };
        }

        private static int MapErrorTypesAndStatusCodes(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.VALIDATION => StatusCodes.Status400BadRequest,

                ErrorType.FAILURE => StatusCodes.Status500InternalServerError,

                ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,

                ErrorType.CONFLICT => StatusCodes.Status409Conflict,

                _ => StatusCodes.Status500InternalServerError
            };
    }
}
