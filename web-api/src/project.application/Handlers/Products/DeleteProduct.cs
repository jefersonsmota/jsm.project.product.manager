using project.domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace project.application.Handlers.Products
{
    public interface IDeleteProduct
    {
        Task Handler(Guid id, CancellationToken cancellationToken);
    }

    public class DeleteProduct : IDeleteProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProduct(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handler(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(id, cancellationToken);

            _productRepository.Delete(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
