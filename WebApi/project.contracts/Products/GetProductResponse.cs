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
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string ImageURL { get; private set; }
    }
}
