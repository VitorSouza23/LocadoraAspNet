using System;
using System.Runtime.Serialization;

namespace LocadoraAspNet.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Entidade ou objeto não encontrados.")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}