using Moq;
using Moq.AutoMock;
using project.application.Handlers.Products;
using project.contracts.Products;
using project.contracts.tests.utils.Configurations;
using project.domain.Entities;
using project.domain.Interfaces.Repositories;

namespace project.application.tests.Handlers.Products
{
    public class UpdateProductTests
    {
        private readonly AutoMocker _mocker;
        private readonly UpdateProduct _subject;

        public UpdateProductTests()
        {
            _mocker = new AutoMocker(Moq.MockBehavior.Strict);
            _subject = _mocker.CreateInstance<UpdateProduct>();
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Application")]
        public async Task Handler_UpdateProduct_ReturnUpdatedProductId()
        {
            // Arrange
            _mocker.GetMock<PutProductRequest>()
                .Setup(x => x.Name).Returns(DefinitionFix.NAME);
            _mocker.GetMock<PutProductRequest>()
                .Setup(x => x.Price).Returns(DefinitionFix.PRICE);
            _mocker.GetMock<PutProductRequest>()
                .Setup(x => x.ImageURL).Returns(DefinitionFix.IMAGEURL);

            _mocker.GetMock<Product>()
                .Setup(x => x.Id).Returns(DefinitionFix.ID);

            _mocker.GetMock<Product>()
                .Setup(p => p.Update(DefinitionFix.NAME, DefinitionFix.PRICE, DefinitionFix.IMAGEURL));

            _mocker.GetMock<IProductRepository>()
                .Setup(x => x.Get(DefinitionFix.ID, CancellationToken.None))
                .ReturnsAsync(_mocker.Get<Product>());

            _mocker.GetMock<IProductRepository>()
                .Setup(x => x.Update(_mocker.Get<Product>(), CancellationToken.None));

            _mocker.GetMock<IUnitOfWork>()
                .Setup(x => x.SaveChangesAsync(CancellationToken.None))
                .Returns(Task.FromResult<int>(0));

            // Act
            var result = await _subject.Handler(DefinitionFix.ID, _mocker.Get<PutProductRequest>(), CancellationToken.None);

            // Assert
            _mocker.VerifyAll();
            Assert.Equal(DefinitionFix.ID, result.Id);
        }
    }
}
