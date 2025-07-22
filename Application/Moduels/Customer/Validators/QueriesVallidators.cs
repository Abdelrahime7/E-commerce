
using FluentValidation;
using static Application.Moduels.Customer.Queries.Queries;

namespace Application.Moduels.Customer.Validators
{
    public class GetByIdValidator :AbstractValidator<GetCustomerByIdQuery>
    {
        public GetByIdValidator() {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
