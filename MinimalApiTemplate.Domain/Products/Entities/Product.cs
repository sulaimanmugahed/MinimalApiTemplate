
using MinimalApiTemplate.Domain.Common;


namespace MinimalApiTemplate.Domain.Products.Entities;


public sealed class Product: BaseEntity, IAuditable, ISoftDeletable
{
    private Product(ProductId id, string name, string description, decimal price) 
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }


    public ProductId Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
 


    public static Product Create(string name, string description, decimal price)
    {
        var product = new Product(new ProductId(Guid.NewGuid()), name, description, price);
        return product;
    }

    public void Update(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

  

    public Guid CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? Deleted { get; set; }
    public Guid? DeletedBy { get; set; }
}

