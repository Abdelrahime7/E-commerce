using FluentValidation;
using static Application.Moduels.Purchase.Queries.Queries;

namespace Application.Moduels.Purchase.Validators
{
    public class GetByIdValidator : AbstractValidator<GetPurchaseByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
