using System;
using System.Collections.Generic;

namespace jsm.product.manager.domain.Exceptions.BaseValidator
{
    public abstract class BaseEntityValidatorException : Exception
    {
        protected BaseEntityValidatorException() { }

        public BaseEntityValidatorException(string message, IDictionary<string, string> errors) : base(message)
        {
            Errors = errors;
        }

        public IDictionary<string, string> Errors { get; private set; }
    }
}
