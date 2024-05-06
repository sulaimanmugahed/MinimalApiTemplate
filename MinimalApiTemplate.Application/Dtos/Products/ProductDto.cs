using MinimalApiTemplate.Domain.Products.Entities;


namespace MinimalApiTemplate.Application.Dtos.Products;
public class ProductDto(Product product)
{
    public Guid Id { get; set; } = product.Id.Value;
    public string Name { get; set; } = product.Name;
    public string Description { get; set; } = product.Description;
    public decimal Price { get; set; } = product.Price;

}
