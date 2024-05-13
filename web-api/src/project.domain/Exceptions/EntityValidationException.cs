using jsm.product.manager.domain.Exceptions.BaseValidator;
using System.Collections.Generic;

namespace jsm.product.manager.domain.Exceptions
{
    public class EntityValidationException : BaseEntityValidatorException
    {
        protected EntityValidationException() : base() { }

        public EntityValidationException(string message, IDictionary<string, string> errors) : base(message, errors)
        {

        }
    }
}
