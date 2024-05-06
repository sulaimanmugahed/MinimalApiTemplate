using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Identity.Models;
public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        Created = DateTime.Now;
    }
    public string Name { get; set; } = string.Empty;
    public DateTime Created { get; set; }
}

