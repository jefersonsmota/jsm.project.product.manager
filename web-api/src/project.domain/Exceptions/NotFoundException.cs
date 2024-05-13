using System;

namespace jsm.product.manager.domain.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string code, string message) : base(message)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
