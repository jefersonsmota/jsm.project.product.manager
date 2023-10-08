namespace project.application.Handlers.Products
{
    public class PostProductResponse
    {
        protected PostProductResponse() { }
        public PostProductResponse(Guid id)
        {
            Id = id;
        }

        public virtual Guid Id { get; private set; }
    }
}
