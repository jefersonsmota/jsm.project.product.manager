using System;
using System.Collections.Generic;

namespace jsm.product.manager.domain.Exceptions.BaseValidator
{
    public abstract class EntityValidator<T> where T : BaseEntityValidatorException
    {
        private IDictionary<string, string> _errors;
        private T _exception;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public EntityValidator() => _errors = new Dictionary<string, string>();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

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
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                _exception = (T)Activator.CreateInstance(typeof(T), EntityErrorMessage(), _errors);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8597 // Thrown value may be null.
                throw _exception;
#pragma warning restore CS8597 // Thrown value may be null.
            }
        }
    }
}
