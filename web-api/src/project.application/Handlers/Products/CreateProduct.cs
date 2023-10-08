using AutoMapper;
using project.contracts.Products;
using project.domain.Entities;
using project.domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace project.application.Handlers.Products
{
    public interface ICreateProduct
    {
        Task<PostProductResponse> Handler(PostProductRequest request, CancellationToken cancellationToken);
    }

    public class CreateProduct : ICreateProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProduct(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PostProductResponse> Handler(PostProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            await _productRepository.Add(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new PostProductResponse(product.Id);
        }
    }
}
