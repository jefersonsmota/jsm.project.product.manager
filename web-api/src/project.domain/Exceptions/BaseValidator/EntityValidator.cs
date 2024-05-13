using System;
using System.Collections.Generic;

namespace jsm.product.manager.domain.Exceptions.BaseValidator
{
    public abstract class EntityValidator<T> where T : BaseEntityValidatorException
    {
        private IDictionary<string, string> _errors;
        private T _exception;

        public EntityValidator()
        {
            _errors = new Dictionary<string, string>();
        }

        protected abstract string EntityErrorMessage();

        protected void Fail(bool validation, string code, string message)
        {
            if (validation)
            {
                _errors.Add(code, message);
            }
        }

        protected abstract void Validations();

        protected void Validate()
        {
            Validations();

            if (_errors.Count > 0)
            {
                _exception = (T)Activator.CreateInstance(typeof(T), EntityErrorMessage(), _errors);
                throw _exception;
            }
        }
    }
}
