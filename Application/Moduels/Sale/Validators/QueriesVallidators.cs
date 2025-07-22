using FluentValidation;
using static Application.Moduels.Sale.Queries.Queries;


namespace Application.Moduels.Sale.Validators
{
    public class GetSaleByIdValidator : AbstractValidator<GetSaleByIdQuery>
    {
        public GetSaleByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
