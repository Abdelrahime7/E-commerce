using Application.Moduels.Invoice.Commands;
using FluentValidation;

namespace Application.Moduels.Invoice.Validators
{
    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {


        public UpdateInvoiceCommandValidator()
        {
            RuleFor(C => C.Request.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.Request.Quantity).NotEmpty().WithMessage("Quantity is required");
            RuleFor(C => C.Request.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.Request.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.Request.OrderID).NotEmpty().WithMessage("OrderID is required");
            RuleFor(C => C.Request.ItemID).NotEmpty().WithMessage("ItemID is required");


        }



    }

}
