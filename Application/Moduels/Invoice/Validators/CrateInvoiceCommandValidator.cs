using Application.DTOs.Invoice;
using Application.Moduels.Invoice.Commands;
using FluentValidation;

namespace Application.Moduels.Invoice.Validators
{
    public class CrateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {

        
        public CrateInvoiceCommandValidator()
        {
            RuleFor(C => C.Dto.Quantity).NotEmpty().WithMessage("Quantity is required");
            RuleFor(C => C.Dto.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.Dto.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.Dto.OrderID).NotEmpty().WithMessage("OrderID is required");
            RuleFor(C => C.Dto.ItemID).NotEmpty().WithMessage("ItemID is required");
                         

        }



    }

}
