using AutoMapper;
using Moq.AutoMock;
using project.application.Handlers.Products;
using project.contracts.Products;
using project.contracts.tests.utils.Configurations;
using project.domain.Entities;
using project.domain.Interfaces.Repositories;

namespace project.application.tests.Handlers.Products
{
    public class CreateProductTests
    {
        private readonly AutoMocker _mocker;
        private readonly CreateProduct _subject;

        public CreateProductTests()
        {
            _mocker = new AutoMocker(Moq.MockBehavior.Strict);
            _subject = _mocker.CreateInstance<CreateProduct>();
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Application")]
        public async Task Handler_CreateProduct_ReturnSavedProductId()
        {
            // Arrange
            _mocker.GetMock<Product>()
                .Setup(x => x.Id).Returns(DefinitionFix.ID);

            _mocker.GetMock<IMapper>()
                .Setup(x => x.Map<Product>(_mocker.Get<PostProductRequest>()))
                .Returns(_mocker.Get<Product>());

            _mocker.GetMock<IProductRepository>()
                .Setup(x => x.Add(_mocker.Get<Product>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            _mocker.GetMock<IUnitOfWork>()
                .Setup(x => x.SaveChangesAsync( CancellationToken.None))
                .Returns(Task.FromResult<int>(0));

            // Act
            var result = await _subject.Handler(_mocker.Get<PostProductRequest>(), CancellationToken.None);

            // Assert
            _mocker.VerifyAll();
            Assert.Equal(DefinitionFix.ID, result.Id);
        }
    }
}
