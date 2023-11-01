using Newtonsoft.Json;
using project.contracts.Products;
using project.contracts.tests.utils.Configurations;

namespace project.contracts.tests.Products
{
    public class GetProductResponseTests
    {
        private readonly dynamic _objJson;
        public GetProductResponseTests()
        {
            _objJson = new
            {
                id = DefinitionFix.ID,
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
            var subject = new GetProductResponse(DefinitionFix.ID, DefinitionFix.NAME, DefinitionFix.PRICE, DefinitionFix.IMAGEURL);

            // Assert
            Assert.Equal(DefinitionFix.ID, subject.Id);
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
            var subject = JsonConvert.DeserializeObject<GetProductResponse>(json);

            // Assert
            Assert.Equal(DefinitionFix.ID, subject.Id);
            Assert.Equal(DefinitionFix.NAME, subject.Name);
            Assert.Equal(DefinitionFix.PRICE, subject.Price);
            Assert.Equal(DefinitionFix.IMAGEURL, subject.ImageURL);
        }
    }
}
