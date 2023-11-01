
using Newtonsoft.Json;

namespace project.contracts.Products
{
    public class GetProductResponse
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected GetProductResponse() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public GetProductResponse(Guid id, string name, decimal price, string imageUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            ImageURL = imageUrl;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; private set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public decimal Price { get; private set; }

        [JsonProperty(PropertyName = "imageURL", Required = Required.Always)]
        public string ImageURL { get; private set; }
    }
}
