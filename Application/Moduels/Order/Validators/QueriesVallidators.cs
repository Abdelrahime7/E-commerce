using FluentValidation;
using static Application.Moduels.Order.Queries.Queries;

namespace Application.Moduels.Order.Validators
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
