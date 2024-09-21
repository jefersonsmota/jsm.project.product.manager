namespace jsm.product.manager.domain.Entities;

public interface IProduct : IEntity
{
    string Name { get; }
    decimal Price { get; }
    string ImageURL { get; }
    void Update(string name, decimal price, string imageUrl);
}
public class Product : Entity, IProduct
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    protected Product() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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
