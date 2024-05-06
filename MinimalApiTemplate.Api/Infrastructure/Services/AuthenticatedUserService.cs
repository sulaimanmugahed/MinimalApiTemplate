using MinimalApiTemplate.Application.Contracts;

using System.Security.Claims;

namespace MinimalApiTemplate.Api.Infrastructure.Services;

public class AuthenticatedUserService : IAuthenticatedUserService
{
    public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        UserName = httpContextAccessor.HttpContext?.User?.Identity.Name;

    }

    public string UserId { get; }
    public string UserName { get; }
}
