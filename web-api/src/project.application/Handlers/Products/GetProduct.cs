using AutoMapper;
using project.contracts.Products;
using project.domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace project.application.Handlers.Products
{
    public interface IGetProduct
    {
        Task<GetProductResponse> Handler(Guid id, CancellationToken cancellationToken);
    }

    public class GetProduct : IGetProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProduct(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductResponse> Handler(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(id, cancellationToken);

            return _mapper.Map<GetProductResponse>(product);
        }
    }
}
