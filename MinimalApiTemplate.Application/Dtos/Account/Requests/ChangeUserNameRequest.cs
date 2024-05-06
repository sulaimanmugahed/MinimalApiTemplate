using FluentValidation;
using MinimalApiTemplate.Application.Helpers;


namespace MinimalApiTemplate.Application.DTOs.Account.Requests
{
    public class ChangeUserNameRequest
    {
        public string UserName { get; set; }
    }
    public class ChangeUserNameRequestValidator : AbstractValidator<ChangeUserNameRequest>
    {
        public ChangeUserNameRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().NotNull()
                .MinimumLength(4)
                .Matches(Regexs.UserName)
                .WithName("UserName");
        }
    }
}
