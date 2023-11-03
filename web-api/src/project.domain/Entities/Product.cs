namespace project.domain.Entities
{
    public interface IProduct : IEntity
    {
        string Name { get; }
        decimal Price { get; }
        string ImageURL { get; }
        void Update(string name, decimal price, string imageUrl);
    }
    public class Product : Entity, IProduct
    {
        protected Product() { }
        public Product(string name, decimal price, string imageUrl)
        {
            this.Name = name;
            this.Price = price;
            this.ImageURL = imageUrl;

            Validate();
        }
        public virtual string Name { get; private set; }
        public virtual decimal Price { get; private set; }
        public virtual string ImageURL { get; private set; }
        protected override void Validations()
        {
            Fail(string.IsNullOrWhiteSpace(Name), "PRODUCT_NAME", "Invalid Name.");
            Fail(Price < 0, "PRODUCT_PRICE", "Invalid Name.");
            Fail(string.IsNullOrWhiteSpace(ImageURL), "PRODUCT_IMAGEURL", "Invalid ImageURL.");
        }
        protected override string EntityErrorMessage() => "Invalid Product.";

        public virtual void Update(string name, decimal price, string imageUrl)
        {
            this.Name = name;
            this.Price = price;
            this.ImageURL = imageUrl;

            Update();
            Validate();
        }
    }
}
