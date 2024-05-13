using System;

namespace jsm.product.manager.domain.Exceptions
{
    public class InvalidOperationBusinessException : InvalidOperationException
    {
        public InvalidOperationBusinessException(string code, string message) : base(message)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
