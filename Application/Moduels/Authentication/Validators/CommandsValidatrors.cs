using Application.Moduels.Customer.Commands;
using FluentValidation;
using static Application.Moduels.Authentication.Queries.Queries;

namespace Application.Moduels.Authentication.Validators
{

    public class AuthenticatValidator : AbstractValidator<AuthenticateUserQuery>
    {


        public AuthenticatValidator()
        {
            RuleFor(U =>U.Request.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(U => U.Request.UserName).NotEmpty().WithMessage("UserName is required");

        }

    }



}
