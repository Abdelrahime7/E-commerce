using Application.Moduels.User.Commands;
using FluentValidation;

namespace Application.Moduels.User.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<SoftDeleteUserCommand>
    {


        public DeleteUserCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
