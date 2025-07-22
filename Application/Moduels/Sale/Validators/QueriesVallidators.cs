using FluentValidation;
using static Application.Moduels.Sale.Queries.Queries


namespace Application.Moduels.Sale.Validators
{
    public class GetByIdValidator : AbstractValidator<GetSaleByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
