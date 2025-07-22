using Application.Moduels.Sale.Commands;
using FluentValidation;

namespace Application.Moduels.Sale.Validators
{

    public class DeleteSaleCommandValidator : AbstractValidator<SoftDeleteSaleCommand>
    {


        public DeleteSaleCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
