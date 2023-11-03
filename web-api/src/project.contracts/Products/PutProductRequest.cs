using Newtonsoft.Json;

namespace project.contracts.Products
{
    public class PutProductRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected PutProductRequest() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public PutProductRequest(string name, decimal price, string imageUrl)
        {
            Name = name;
            Price = price;
            ImageURL = imageUrl;
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public virtual string Name { get; private set; }

        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public virtual decimal Price { get; private set; }

        [JsonProperty(PropertyName = "imageURL", Required = Required.Always)]
        public virtual string ImageURL { get; private set; }
    }
}
