using AutoMapper;
using Moq;
using Moq.AutoMock;
using jsm.product.manager.application.Handlers.Products;
using jsm.product.manager.contracts.Products;
using jsm.product.manager.domain.Entities;
using jsm.product.manager.domain.Interfaces.Repositories;

namespace jsm.product.manager.application.tests.Handlers.Products
{
    public class GetAllProductsTests
    {
        private readonly AutoMocker _mocker;
        private readonly GetAllProducts _subject;

        public GetAllProductsTests()
        {
            _mocker = new AutoMocker(Moq.MockBehavior.Strict);
            _subject = _mocker.CreateInstance<GetAllProducts>();
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Application")]
        public async Task Handler_GetAllProducts_ReturnListProduct()
        {
            // Arrange
            _mocker.GetMock<IProductRepository>()
                .Setup(x => x.GetAll(0, 1, CancellationToken.None))
                .ReturnsAsync(_mocker.Get<IEnumerable<Product>>());

            _mocker.GetMock<IMapper>()
                .Setup(x => x.Map<GetProductListResponse>(_mocker.Get<IEnumerable<Product>>()))
                .Returns(_mocker.Get<GetProductListResponse>());

            // Act
            var result = await _subject.Handler(0, 1, CancellationToken.None);

            // Assert
            _mocker.VerifyAll();
            Assert.Same(_mocker.Get<GetProductListResponse>(), result);
        }
    }
}
