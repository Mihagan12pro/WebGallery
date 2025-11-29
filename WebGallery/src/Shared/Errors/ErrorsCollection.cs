using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Errors
{
    public class ErrorsCollection : IEnumerable<Error>
    {
        private readonly List<Error> _errors;

        public IEnumerator<Error> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ErrorsCollection(IEnumerable<Error> errors)
        {
            _errors = [.. errors];
        }

        public static implicit operator ErrorsCollection(Error[] errors)
            => new(errors);

        public static implicit operator ErrorsCollection(Error error)
            => new([error]);
    }
}
