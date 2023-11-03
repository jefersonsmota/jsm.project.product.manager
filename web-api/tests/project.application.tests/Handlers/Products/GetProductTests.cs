using AutoMapper;
using Moq;
using Moq.AutoMock;
using project.application.Handlers.Products;
using project.contracts.Products;
using project.contracts.tests.utils.Configurations;
using project.domain.Entities;
using project.domain.Interfaces.Repositories;

namespace project.application.tests.Handlers.Products
{
    public class GetProductTests
    {
        private readonly AutoMocker _mocker;
        private readonly GetProduct _subject;

        public GetProductTests()
        {
            _mocker = new AutoMocker(Moq.MockBehavior.Strict);
            _subject = _mocker.CreateInstance<GetProduct>();
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Application")]
        public async Task Handler_GetProduct_ReturnProduct()
        {
            // Arrange
            _mocker.GetMock<IProductRepository>()
                .Setup(x => x.Get(DefinitionFix.ID, CancellationToken.None))
                .ReturnsAsync(_mocker.Get<Product>());

            _mocker.GetMock<IMapper>()
                .Setup(x => x.Map<GetProductResponse>(_mocker.Get<Product>()))
                .Returns(_mocker.Get<GetProductResponse>());

            // Act
            var result = await _subject.Handler(DefinitionFix.ID, CancellationToken.None);

            // Assert
            _mocker.VerifyAll();
            Assert.Same(_mocker.Get<GetProductResponse>(), result);
        }
    }
}
