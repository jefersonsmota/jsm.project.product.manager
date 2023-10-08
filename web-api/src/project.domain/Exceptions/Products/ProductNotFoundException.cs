using System;
using System.Runtime.Serialization;

namespace project.domain.Exceptions.Products
{
    [Serializable]
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(string code, Guid productId) : base(code, $"Product id {productId} not found.")
        {
            ProductId = productId;
        }

        public Guid ProductId { get; private set; }

        public ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
