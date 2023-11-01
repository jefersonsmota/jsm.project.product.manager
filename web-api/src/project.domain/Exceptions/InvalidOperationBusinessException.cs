using System;
using System.Runtime.Serialization;

namespace project.domain.Exceptions
{
    [Serializable]
    public class InvalidOperationBusinessException : InvalidOperationException
    {
        public InvalidOperationBusinessException(string code, string message) : base(message)
        {
            Code = code;
        }

        public string Code { get; private set; }

        public InvalidOperationBusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
