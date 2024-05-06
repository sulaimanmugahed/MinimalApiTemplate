using Microsoft.EntityFrameworkCore;

using MinimalApiTemplate.Domain.Products.Entities;
using MinimalApiTemplate.Domain.Common;
using MinimalApiTemplate.Application.Contracts;
using MinimalApiTemplate.Domain.Products;


namespace MinimalApiTemplate.Persistence.Contexts;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAuthenticatedUserService authenticatedUserService)
    : DbContext(options)
{
    public DbSet<Product> Products { get; set; }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var userId = Guid.Parse(authenticatedUserService.UserId ?? "00000000-0000-0000-0000-000000000000");

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is IAuditable auditableEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditableEntity.Create(userId);
                        break;
                    case EntityState.Modified:
                        auditableEntity.Update(userId);
                        break;
                }
            }

            if (entry.Entity is ISoftDeletable fakeDeletableEntity && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                fakeDeletableEntity.Delete(userId);
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        foreach (var property in builder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,6)");
        }
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }

}
