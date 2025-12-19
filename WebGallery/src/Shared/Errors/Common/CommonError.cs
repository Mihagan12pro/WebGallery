using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Errors.Common
{
    public abstract class CommonError
    {
        public abstract Error Error { get; }

        public Failure Failure =>
            Error.ToCollection();
    }
}
