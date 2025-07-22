using FluentValidation;
using static Application.Moduels.Invoice.Queries.Queries;

namespace Application.Moduels.Invoice.Validators
{
    public class GetInvoiceByIdValidator : AbstractValidator<GetInvoiceByIdQuery>
    {
        public GetInvoiceByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
