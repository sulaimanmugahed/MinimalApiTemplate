using Microsoft.EntityFrameworkCore;
using MinimalApiTemplate.Application.Contracts.Persistence;
using MinimalApiTemplate.Domain.Products;
using MinimalApiTemplate.Domain.Products.Entities;
using MinimalApiTemplate.Persistence.Contexts;



namespace MinimalApiTemplate.Persistence.Repositories;
public class ProductRepository(ApplicationDbContext context) 
    : GenericRepository<Product,ProductId>(context),
    IProductRepository
{
    private readonly DbSet<Product> _product = context.Set<Product>();


}
