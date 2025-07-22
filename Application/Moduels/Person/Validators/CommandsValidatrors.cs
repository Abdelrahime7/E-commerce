using Application.Moduels.Person.Commands;
using FluentValidation;

namespace Application.Moduels.Person.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreatePersonCommand>
    {

        
        public CrateCommandValidator()
        {
            RuleFor(C => C.personDto.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.personDto.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.personDto.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.personDto.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");

        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdatePersonCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.Response.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.Response.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.Response.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");


        }



    }

    public class DeleteCommandValidator : AbstractValidator<SoftDeletePersonCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
