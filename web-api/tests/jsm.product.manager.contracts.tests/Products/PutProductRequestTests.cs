using Newtonsoft.Json;
using jsm.product.manager.contracts.Products;
using jsm.product.manager.contracts.tests.utils.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsm.product.manager.contracts.tests.Products
{
    public class PutProductRequestTests
    {
        private readonly dynamic _objJson;
        public PutProductRequestTests()
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
            var subject = new PutProductRequest(DefinitionFix.NAME, DefinitionFix.PRICE, DefinitionFix.IMAGEURL);

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
            var subject = JsonConvert.DeserializeObject<PutProductRequest>(json);

            // Assert
            Assert.Equal(DefinitionFix.NAME, subject.Name);
            Assert.Equal(DefinitionFix.PRICE, subject.Price);
            Assert.Equal(DefinitionFix.IMAGEURL, subject.ImageURL);
        }
    }
}
