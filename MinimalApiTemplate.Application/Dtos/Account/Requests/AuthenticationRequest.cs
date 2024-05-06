using FluentValidation;
using MinimalApiTemplate.Application.Helpers;


namespace MinimalApiTemplate.Application.DTOs.Account.Requests
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().NotNull().WithName("UserName");

            RuleFor(x => x.Password)
                .NotEmpty().NotNull()
                .Matches(Regexs.Password).WithName("Password");
        }
    }
}
