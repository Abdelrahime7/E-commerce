using Application.Moduels.User.Commands;
using FluentValidation;

namespace Application.Moduels.User.Validators
{
    public class CrateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
       
        public CrateUserCommandValidator()
        {
            RuleFor(C => C.userDto.UserName).NotEmpty().WithMessage("UserName  is required");
            RuleFor(C => C.userDto.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(C => C.userDto.IsAdmin).NotNull().WithMessage("Admin status must be specified.");
            RuleFor(C => C.userDto.IsGuest).NotNull().WithMessage("Guest status must be specified.");

           

        }



    }


}
