using Application.Moduels.Person.Commands;
using FluentValidation;

namespace Application.Moduels.Person.Validators
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {


        public UpdatePersonCommandValidator()
        {
            RuleFor(C => C.request.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.request.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.request.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.request.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.request.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");


        }



    }

}
