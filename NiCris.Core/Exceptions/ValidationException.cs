using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NiCris.Core.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException()
            : base() { }

        public ValidationException(string message)
            : base(message) { }

        public ValidationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException) { }

        public ValidationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
