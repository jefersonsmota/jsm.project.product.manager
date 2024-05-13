using Moq;
using Moq.AutoMock;
using jsm.product.manager.application.Handlers.Products;
using jsm.product.manager.contracts.tests.utils.Configurations;
using jsm.product.manager.domain.Entities;
using jsm.product.manager.domain.Interfaces.Repositories;

namespace jsm.product.manager.application.tests.Handlers.Products
{
    public class DeleteProductTests
    {
        private readonly AutoMocker _mocker;
        private readonly DeleteProduct _subject;

        public DeleteProductTests()
        {
            _mocker = new AutoMocker(Moq.MockBehavior.Strict);
            _subject = _mocker.CreateInstance<DeleteProduct>();
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Application")]
        public async Task Handler_DeleteProduct()
        {
            // Arrange
            _mocker.GetMock<IProductRepository>()
                .Setup(x => x.Get(DefinitionFix.ID, CancellationToken.None))
                .ReturnsAsync(_mocker.Get<Product>());

            _mocker.GetMock<IProductRepository>()
                .Setup(x => x.Delete(_mocker.Get<Product>(), CancellationToken.None));

            _mocker.GetMock<IUnitOfWork>()
                .Setup(x => x.SaveChangesAsync(CancellationToken.None))
                .Returns(Task.FromResult<int>(0));

            // Act
            await _subject.Handler(DefinitionFix.ID, CancellationToken.None);

            // Assert
            _mocker.VerifyAll();
        }
    }
}
