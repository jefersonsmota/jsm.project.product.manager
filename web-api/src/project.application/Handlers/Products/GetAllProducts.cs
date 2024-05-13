using AutoMapper;
using jsm.product.manager.contracts.Products;
using jsm.product.manager.domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace jsm.product.manager.application.Handlers.Products
{
    public interface IGetAllProducts
    {
        Task<GetProductListResponse> Handler(int skip, int take, CancellationToken cancellationToken);
    }

    public class GetAllProducts : IGetAllProducts
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProducts(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductListResponse> Handler(int skip, int take, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(skip, take, cancellationToken);

            return _mapper.Map<GetProductListResponse>(products);
        }
    }
}
