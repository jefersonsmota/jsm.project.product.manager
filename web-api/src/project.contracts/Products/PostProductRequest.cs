using Newtonsoft.Json;

namespace project.contracts.Products
{
    public class PostProductRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected PostProductRequest() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public PostProductRequest(string name, decimal price, string imageUrl)
        {
            Name = name;
            Price = price;
            ImageURL = imageUrl;
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public decimal Price { get; private set; }

        [JsonProperty(PropertyName = "imageURL", Required = Required.Always)]
        public string ImageURL { get; private set; }
    }
}
