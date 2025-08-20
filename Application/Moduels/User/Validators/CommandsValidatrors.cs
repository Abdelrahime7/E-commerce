using Application.Moduels.User.Commands;
using FluentValidation;

namespace Application.Moduels.User.Validators
{

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {


        public UpdateUserCommandValidator()
        {
            RuleFor(C => C.request.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.request.UserName).NotEmpty().WithMessage("UserName  is required");
            RuleFor(C => C.request.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(C => C.request.IsAdmin).NotNull().WithMessage("Admin status must be specified.");
            RuleFor(C => C.request.IsGuest).NotNull().WithMessage("Guest status must be specified.");


        }



    }


}
