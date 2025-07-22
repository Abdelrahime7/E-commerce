using Application.Moduels.Invoice.Commands;
using FluentValidation;

namespace Application.Moduels.Invoice.Validators
{

    public class DeleteInvoiceCommandValidator : AbstractValidator<SoftDeleteInvoiceCommand>
    {


        public DeleteInvoiceCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
