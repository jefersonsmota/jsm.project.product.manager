using AutoMapper;
using jsm.product.manager.contracts.Products;
using jsm.product.manager.domain.Entities;
using jsm.product.manager.domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace jsm.product.manager.application.Handlers.Products;

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
