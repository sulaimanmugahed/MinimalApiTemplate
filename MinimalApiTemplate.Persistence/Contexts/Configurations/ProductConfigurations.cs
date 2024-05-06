using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApiTemplate.Domain.Products;
using MinimalApiTemplate.Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Persistence.Contexts.Configurations;
public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
              .ToTable("Products", schema: "Base");

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasConversion(id => id.Value,value => new ProductId(value));

        builder
            .HasQueryFilter(p => !p.IsDeleted);

    }
}

