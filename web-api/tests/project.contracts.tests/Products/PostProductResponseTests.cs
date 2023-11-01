using Newtonsoft.Json;
using project.application.Handlers.Products;
using project.contracts.tests.utils.Configurations;

namespace project.contracts.tests.Products
{
    public class PostProductResponseTests
    {
        private readonly dynamic _objJson;
        public PostProductResponseTests()
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
            var subject = new PostProductResponse(DefinitionFix.ID);

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
            var subject = JsonConvert.DeserializeObject<PostProductResponse>(json);

            // Assert
            Assert.Equal(DefinitionFix.ID, subject.Id);
        }
    }
}
