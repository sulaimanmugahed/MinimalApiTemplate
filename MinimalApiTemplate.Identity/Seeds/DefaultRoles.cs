using Microsoft.AspNetCore.Identity;
using MinimalApiTemplate.Identity.Models;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
        {
            //Seed Roles
            if (!await roleManager.RoleExistsAsync("SuperAdmin"))
                await roleManager.CreateAsync(new ApplicationRole("SuperAdmin"));
        }
    }
}
