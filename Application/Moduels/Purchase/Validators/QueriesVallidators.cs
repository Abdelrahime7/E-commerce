using FluentValidation;
using static Application.Moduels.Purchase.Queries.Queries;

namespace Application.Moduels.Purchase.Validators
{
    public class GetPurchaseByIdValidator : AbstractValidator<GetPurchaseByIdQuery>
    {
        public GetPurchaseByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
