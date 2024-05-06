using Microsoft.EntityFrameworkCore;
using MinimalApiTemplate.Identity.Contexts;
using MinimalApiTemplate.Persistence.Contexts;

namespace MinimalApiTemplate.Api.Infrastructure.Extensions;

public static class ApplyMigrationsExtension
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        services.GetRequiredService<IdentityContext>().Database.Migrate();
        services.GetRequiredService<ApplicationDbContext>().Database.Migrate();
    }
}
