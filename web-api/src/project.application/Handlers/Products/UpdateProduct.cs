using project.contracts.Products;
using project.domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace project.application.Handlers.Products
{
    public interface IUpdateProduct
    {
        Task<PutProductResponse> Handler(Guid id, PutProductRequest request, CancellationToken cancellationToken);
    }

    public class UpdateProduct : IUpdateProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProduct(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PutProductResponse> Handler(Guid id, PutProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(id, cancellationToken);
            product.Update(request.Name, request.Price, request.ImageURL);

            _productRepository.Update(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new PutProductResponse(product.Id);
        }
    }
}
