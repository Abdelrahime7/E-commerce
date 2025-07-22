using FluentValidation;
using static Application.Moduels.Invoice.Queries.Queries;

namespace Application.Moduels.Invoice.Validators
{
    public class GetByIdValidator : AbstractValidator<GetInvoiceByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
