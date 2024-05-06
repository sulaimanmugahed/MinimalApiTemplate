using Microsoft.AspNetCore.Identity;


namespace MinimalApiTemplate.Identity.Models;
public class ApplicationRole(string name): IdentityRole<Guid>(name)
{

}
