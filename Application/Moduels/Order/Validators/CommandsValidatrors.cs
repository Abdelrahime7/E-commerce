using Application.Moduels.Order.Commands;
using FluentValidation;

namespace Application.Moduels.Order.Validators
{

    public class DeleteOrderCommandValidator : AbstractValidator<SoftDeleteOrderCommand>
    {


        public DeleteOrderCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
