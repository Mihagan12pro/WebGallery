using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Errors.Enums
{
    public enum ErrorType
    {
        /// <summary>
        /// Unknown error
        /// </summary>
        NONE,

        /// <summary>
        /// Validation error
        /// </summary>
        VALIDATION,

        /// <summary>
        /// Not found error
        /// </summary>
        NOT_FOUND,

        /// <summary>
        /// Server error
        /// </summary>
        FAILURE,

        /// <summary>
        /// Conflict error
        /// </summary>
        CONFLICT,
    }
}
