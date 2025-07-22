using FluentValidation;
using static Application.Moduels.Inventory.Queries.Queries;

namespace Application.Moduels.Inventory.Validators
{
    public class GetInventoryByIdValidator : AbstractValidator<GetInventoryByIdQuery>
    {
        public GetInventoryByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
