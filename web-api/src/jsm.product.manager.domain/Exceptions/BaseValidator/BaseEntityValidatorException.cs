using System;
using System.Collections.Generic;

namespace jsm.product.manager.domain.Exceptions.BaseValidator
{
    public abstract class BaseEntityValidatorException : Exception
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        protected BaseEntityValidatorException() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public BaseEntityValidatorException(string message, IDictionary<string, string> errors) : base(message)
        {
            Errors = errors;
        }

        public IDictionary<string, string> Errors { get; private set; }
    }
}
