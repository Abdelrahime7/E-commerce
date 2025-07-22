using Application.Moduels.Item.Commands;
using Domain.Enums;
using FluentValidation;

namespace Application.Moduels.Item.Validators
{
    public class DeleteItemCommandValidator : AbstractValidator<SoftDeleteItemCommand>
    {


        public DeleteItemCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
