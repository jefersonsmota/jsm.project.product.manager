using System;
using System.Runtime.Serialization;

namespace project.domain.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string code, string message) : base(message)
        {
            Code = code;
        }

        public string Code { get; private set; }
        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
