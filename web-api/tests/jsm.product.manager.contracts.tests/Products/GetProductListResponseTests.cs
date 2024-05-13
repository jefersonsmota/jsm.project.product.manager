using Moq.AutoMock;
using jsm.product.manager.contracts.Products;

namespace jsm.product.manager.contracts.tests.Products
{
    public class GetProductListResponseTests
    {
        private readonly AutoMocker _mocker;
        public GetProductListResponseTests()
        {
            _mocker = new AutoMocker(Moq.MockBehavior.Strict);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void Construct_Empty()
        {
            // Act 
            var subject = new GetProductListResponse();

            // Assert
            Assert.Empty(subject);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void Construct_IncludItems()
        {
            // Act 
            var subject = new GetProductListResponse();
            subject.Add(_mocker.Get<GetProductResponse>());

            // Assert
            _mocker.VerifyAll();
            var item = Assert.Single(subject);
            Assert.Same(_mocker.Get<GetProductResponse>(), item);
        }
    }
}
