using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace project.domain.Exceptions.BaseValidator
{

    [Serializable]
    public abstract class BaseEntityValidatorException : Exception
    {
        protected BaseEntityValidatorException() { }

        public BaseEntityValidatorException(string message, IDictionary<string, string> errors) : base(message)
        {
            Errors = errors;
        }

        public IDictionary<string, string> Errors { get; private set; }

        public BaseEntityValidatorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Errors = (IDictionary<string, string>)info.GetValue("Errors", typeof(IDictionary<string, string>));
        }
    }
}
