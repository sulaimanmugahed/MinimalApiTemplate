using MinimalApiTemplate.Domain.Products;
using MinimalApiTemplate.Domain.Products.Entities;

namespace MinimalApiTemplate.Application.Contracts.Persistence;
public interface IProductRepository : IGenericRepository<Product, ProductId>
{

}
