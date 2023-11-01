using project.domain.Exceptions.BaseValidator;
using System;
using System.Collections.Generic;

namespace project.domain.Exceptions
{
    [Serializable]
    public class EntityValidationException : BaseEntityValidatorException
    {
        protected EntityValidationException() : base() { }

        public EntityValidationException(string message, IDictionary<string, string> errors) : base(message, errors)
        {

        }
    }
}
