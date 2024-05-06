

using Microsoft.EntityFrameworkCore;
using MinimalApiTemplate.Domain.Products;
using MinimalApiTemplate.Domain.Products.Entities;
using MinimalApiTemplate.Persistence.Contexts;

namespace MinimalApiTemplate.Persistence.Seeds;

public static class DefaultData
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {

        if (!await context.Products.AnyAsync())
        {
            context.Products
            .Add(Product.Create("Defualt Product Name", "Defualt Product Description", 5000));
            await context.SaveChangesAsync();

        }

     

    }
}

