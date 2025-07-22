using FluentValidation;
using static Application.Moduels.Order.Queries.Queries;

namespace Application.Moduels.Order.Validators
{
    public class GetByIdValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
