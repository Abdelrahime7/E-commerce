using Application.Moduels.Inventory.Commands;
using FluentValidation;

namespace Application.Moduels.Inventory.Validators
{


    public class DeleteInventoryCommandValidator : AbstractValidator<SoftDeleteInventoryCommand>
    {
        public DeleteInventoryCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }
}
