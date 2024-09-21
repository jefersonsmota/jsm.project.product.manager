using jsm.product.manager.contracts.tests.utils.Configurations;
using jsm.product.manager.domain.Entities;

namespace jsm.product.manager.domain.tests.Entities
{
    public class ProductTests
    {
        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void Construct()
        {
            // Act
            var subject = new Product(DefinitionFix.NAME, DefinitionFix.PRICE, DefinitionFix.IMAGEURL);

            // Assert
            Assert.NotEqual(Guid.Empty, subject.Id);
            Assert.Equal(DefinitionFix.NAME, subject.Name);
            Assert.Equal(DefinitionFix.PRICE, subject.Price);
            Assert.Equal(DefinitionFix.IMAGEURL, subject.ImageURL);
            Assert.Equal(DateTimeKind.Utc, subject.CreatedDateUtc.Kind);
            Assert.Null(subject.LastUpdateDataUtc);
            Assert.Null(subject.DeleteDateUtc);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        [Trait("Project", "Contracts")]
        public void Construct_Update()
        {
            // Act
            var subject = new Product(DefinitionFix.NAME, DefinitionFix.PRICE, DefinitionFix.IMAGEURL);
            var lastUpdate = subject.LastUpdateDataUtc;
            var created = subject.CreatedDateUtc;

            // Assert
            Assert.NotEqual(Guid.Empty, subject.Id);
            Assert.Equal(DefinitionFix.NAME, subject.Name);
            Assert.Equal(DefinitionFix.PRICE, subject.Price);
            Assert.Equal(DefinitionFix.IMAGEURL, subject.ImageURL);
            Assert.Equal(DateTimeKind.Utc, subject.CreatedDateUtc.Kind);
            Assert.Null(subject.LastUpdateDataUtc);
            Assert.Null(subject.DeleteDateUtc);

            subject.Update(DefinitionFix.NAME + "-new", 2000.0m, DefinitionFix.IMAGEURL + "-new");

            // Assert
            Assert.Equal(DefinitionFix.NAME + "-new", subject.Name);
            Assert.Equal(2000.0m, subject.Price);
            Assert.Equal(DefinitionFix.IMAGEURL + "-new", subject.ImageURL);
            Assert.Equal(created, subject.CreatedDateUtc);
            Assert.NotEqual(lastUpdate, subject.LastUpdateDataUtc);
            Assert.Null(subject.DeleteDateUtc);
        }
    }
}
