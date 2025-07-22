using Application.Moduels.User.Commands;
using FluentValidation;

namespace Application.Moduels.User.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateUserCommand>
    {
       
        public CrateCommandValidator()
        {
            RuleFor(C => C.userDto.UserName).NotEmpty().WithMessage("UserName  is required");
            RuleFor(C => C.userDto.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(C => C.userDto.IsAdmin).NotNull().WithMessage("Admin status must be specified.");
            RuleFor(C => C.userDto.IsGuest).NotNull().WithMessage("Guest status must be specified.");

           

        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdateUserCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.UserName).NotEmpty().WithMessage("UserName  is required");
            RuleFor(C => C.Response.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(C => C.Response.IsAdmin).NotNull().WithMessage("Admin status must be specified.");
            RuleFor(C => C.Response.IsGuest).NotNull().WithMessage("Guest status must be specified.");


        }



    }

    public class DeleteCommandValidator : AbstractValidator<SoftDeleteUserCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
