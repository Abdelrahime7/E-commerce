using Application.Moduels.Purchase.Commands;
using FluentValidation;

namespace Application.Moduels.Purchase.Validators
{
    public class DeletePurchaseCommandValidator : AbstractValidator<SoftDeletePurchaseCommand>
    {


        public DeletePurchaseCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
