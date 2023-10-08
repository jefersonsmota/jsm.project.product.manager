namespace project.contracts.Products
{
    public class PutProductResponse
    {
        protected PutProductResponse() { }
        public PutProductResponse(Guid id)
        {
            Id = id;
        }

        public virtual Guid Id { get; private set; }
    }
}
