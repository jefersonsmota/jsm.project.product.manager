using Newtonsoft.Json;

namespace project.contracts.Products
{
    public class PutProductResponse
    {
        protected PutProductResponse() { }
        public PutProductResponse(Guid id)
        {
            Id = id;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; private set; }
    }
}
