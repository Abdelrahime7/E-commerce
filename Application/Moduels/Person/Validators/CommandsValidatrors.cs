using Application.Moduels.Person.Commands;
using FluentValidation;

namespace Application.Moduels.Person.Validators
{

    public class DeletePersonCommandValidator : AbstractValidator<SoftDeletePersonCommand>
    {


        public DeletePersonCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
