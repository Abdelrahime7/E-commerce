using Application.Moduels.User.Commands;
using FluentValidation;

namespace Application.Moduels.User.Validators
{

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {


        public UpdateUserCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.UserName).NotEmpty().WithMessage("UserName  is required");
            RuleFor(C => C.Response.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(C => C.Response.IsAdmin).NotNull().WithMessage("Admin status must be specified.");
            RuleFor(C => C.Response.IsGuest).NotNull().WithMessage("Guest status must be specified.");


        }



    }


}
