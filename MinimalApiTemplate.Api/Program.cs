using MinimalApiTemplate.Api.Endpoints;
using MinimalApiTemplate.Api.Infrastructure.Extensions;
using MinimalApiTemplate.Api.Infrastructure.Middlewares;
using MinimalApiTemplate.Api.Infrastructure.Services;
using MinimalApiTemplate.Application.Contracts;
using MinimalApiTemplate.Application;
using MinimalApiTemplate.Persistence;
using MinimalApiTemplate.Identity;
using MinimalApiTemplate.Persistence.Seeds;
using MinimalApiTemplate.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using MinimalApiTemplate.Identity.Models;
using MinimalApiTemplate.Identity.Seeds;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddSwaggerWithVersioning();

builder.Services.AddCors(x =>
{
    x.AddPolicy("Any", b =>
    {
        b.AllowAnyOrigin();
        b.AllowAnyHeader();
        b.AllowAnyMethod();
    });
});

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DefaultData.SeedAsync(services.GetRequiredService<ApplicationDbContext>());
    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
}


app.UseCors("Any");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseErrorHandlerMiddleware();
app.MapAppEndpoints();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var desc in descriptions)
        {
            string url = $"/swagger/{desc.GroupName}/swagger.json";
            string name = desc.GroupName.ToUpperInvariant();
            option.SwaggerEndpoint(url, name);
        }
    });

}

app.Run();

