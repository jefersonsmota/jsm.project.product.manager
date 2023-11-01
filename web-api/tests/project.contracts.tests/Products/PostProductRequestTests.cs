using Newtonsoft.Json;
using project.contracts.Products;
using project.contracts.tests.utils.Configurations;

namespace project.contracts.tests.Products
{
    public class PostProductRequestTests
    {
        private readonly dynamic _objJson;
        public PostProductRequestTests()
        {
            _objJson = new
            {
                name = DefinitionFix.NAME,
                price = DefinitionFix.PRICE,
                imageURL = DefinitionFix.IMAGEURL
            };
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void Construct()
        {
            // Act
            var subject = new PostProductRequest(DefinitionFix.NAME, DefinitionFix.PRICE, DefinitionFix.IMAGEURL);

            // Assert
            Assert.Equal(DefinitionFix.NAME, subject.Name);
            Assert.Equal(DefinitionFix.PRICE, subject.Price);
            Assert.Equal(DefinitionFix.IMAGEURL, subject.ImageURL);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void ConvertJsonToContract()
        {
            // Arrange
            var json = JsonConvert.SerializeObject(_objJson);

            // Act
            var subject = JsonConvert.DeserializeObject<PostProductRequest>(json);

            // Assert
            Assert.Equal(DefinitionFix.NAME, subject.Name);
            Assert.Equal(DefinitionFix.PRICE, subject.Price);
            Assert.Equal(DefinitionFix.IMAGEURL, subject.ImageURL);
        }
    }
}
