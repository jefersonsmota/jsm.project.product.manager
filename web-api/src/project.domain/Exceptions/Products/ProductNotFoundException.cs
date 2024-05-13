using System;

namespace jsm.product.manager.domain.Exceptions.Products
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(string code, Guid productId) : base(code, $"Product id {productId} not found.")
        {
            ProductId = productId;
        }

        public Guid ProductId { get; private set; }
    }
}
