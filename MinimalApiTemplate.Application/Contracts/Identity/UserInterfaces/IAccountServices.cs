
using MinimalApiTemplate.Application.DTOs.Account.Requests;
using MinimalApiTemplate.Application.DTOs.Account.Responses;
using MinimalApiTemplate.Application.Wrappers;

namespace MinimalApiTemplate.Application.Contracts.Identity
{
    public interface IAccountServices
    {
        Task<BaseResult<string>> RegisterGostAccount();
        Task<BaseResult> ChangePassword(ChangePasswordRequest model);
        Task<BaseResult> ChangeUserName(ChangeUserNameRequest model);
        Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
        Task<BaseResult<AuthenticationResponse>> AuthenticateByUserName(string username);

    }
}
