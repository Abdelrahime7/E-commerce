using FluentValidation;
using static Application.Moduels.Authentication.Commands.Commands;

namespace Application.Moduels.Authentication.Validators
{
    public class LogoutValidator : AbstractValidator<LogoutCommand>
    {


        public LogoutValidator()
        {
            RuleFor(L => L.Request.RefreshToken).NotEmpty().WithMessage("Token is required");
        }

    }



}
