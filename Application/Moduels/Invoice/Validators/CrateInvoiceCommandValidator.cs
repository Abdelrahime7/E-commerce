using Application.Moduels.Invoice.Commands;
using FluentValidation;

namespace Application.Moduels.Invoice.Validators
{
    public class CrateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {

        
        public CrateInvoiceCommandValidator()
        {
            RuleFor(C => C.invoiceDto.Quantity).NotEmpty().WithMessage("Quantity is required");
            RuleFor(C => C.invoiceDto.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.invoiceDto.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.invoiceDto.OrderID).NotEmpty().WithMessage("OrderID is required");
            RuleFor(C => C.invoiceDto.ItemID).NotEmpty().WithMessage("ItemID is required");
               

        }



    }

}
