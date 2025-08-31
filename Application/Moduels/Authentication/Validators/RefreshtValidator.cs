using FluentValidation;
using static Application.Moduels.Authentication.Commands.Commands;

namespace Application.Moduels.Authentication.Validators
{
    public class RefreshtValidator : AbstractValidator<RefreshCommand>
    {


        public RefreshtValidator()
        {
            RuleFor(R => R.Request.RefreshToken).NotEmpty().WithMessage("Token is required");
        }

    }



}
