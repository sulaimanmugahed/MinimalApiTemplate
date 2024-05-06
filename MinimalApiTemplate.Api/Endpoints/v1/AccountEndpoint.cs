using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTemplate.Application.Contracts.Identity;
using MinimalApiTemplate.Application.DTOs.Account.Requests;
using MinimalApiTemplate.Application.DTOs.Account.Responses;
using MinimalApiTemplate.Application.Wrappers;
using MinimalApiTemplate.Identity.Services;

namespace MinimalApiTemplate.Api.Endpoints.v1;

public static class AccountEndpoint
{

    public static void MapAccountEndpointV1(this IEndpointRouteBuilder routeBuilder)
    {
        var app = routeBuilder.MapGroup("/Account")
        .WithTags("Account")
        .MapToApiVersion(1)
        .WithOpenApi();

        app.MapPost(nameof(Authenticate), Authenticate);
        app.MapPut(nameof(ChangeUserName), ChangeUserName);
        app.MapPut(nameof(ChangePassword), ChangePassword);
        app.MapPost(nameof(Start), Start);
        


    }

   
    private static async Task<BaseResult<AuthenticationResponse>> Authenticate([FromServices]IAccountServices accountServices,AuthenticationRequest request)
            => await accountServices.Authenticate(request);

    [Authorize]
    private static async Task<BaseResult> ChangeUserName([FromServices] IAccountServices accountServices, ChangeUserNameRequest model)
        => await accountServices.ChangeUserName(model);

    [Authorize]
    private static async Task<BaseResult> ChangePassword([FromServices] IAccountServices accountServices, ChangePasswordRequest model)
        => await accountServices.ChangePassword(model);


    private static async Task<BaseResult<AuthenticationResponse>> Start([FromServices] IAccountServices accountServices)
    {
        var gostUsername = await accountServices.RegisterGostAccount();
        return await accountServices.AuthenticateByUserName(gostUsername.Data);
    }
}
