using Newtonsoft.Json;
using jsm.product.manager.contracts.Products;
using jsm.product.manager.contracts.tests.utils.Configurations;

namespace jsm.product.manager.contracts.tests.Products
{
    public class PutProductResponseTests
    {
        private readonly dynamic _objJson;
        public PutProductResponseTests()
        {
            _objJson = new
            {
                id = DefinitionFix.ID
            };
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void Construct()
        {
            // Act
            var subject = new PutProductResponse(DefinitionFix.ID);

            // Assert
            Assert.Equal(DefinitionFix.ID, subject.Id);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void ConvertJsonToContract()
        {
            // Arrange
            var json = JsonConvert.SerializeObject(_objJson);

            // Act
            var subject = JsonConvert.DeserializeObject<PutProductResponse>(json);

            // Assert
            Assert.Equal(DefinitionFix.ID, subject.Id);
        }
    }
}
