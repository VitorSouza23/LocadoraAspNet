using System;
using System.Runtime.Serialization;

namespace LocadoraAspNet.Exceptions
{
    public class NotActivedException : Exception
    {
        public NotActivedException()
        {
        }

        public NotActivedException(string message) : base(message)
        {
        }

        public NotActivedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotActivedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}