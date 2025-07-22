using Application.Moduels.Person.Commands;
using FluentValidation;

namespace Application.Moduels.Person.Validators
{
    public class CratePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {

        
        public CratePersonCommandValidator()
        {
            RuleFor(C => C.personDto.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.personDto.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.personDto.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.personDto.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");

        }



    }

}
