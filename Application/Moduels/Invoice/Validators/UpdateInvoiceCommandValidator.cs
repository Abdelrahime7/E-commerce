using Application.Moduels.Invoice.Commands;
using FluentValidation;

namespace Application.Moduels.Invoice.Validators
{
    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {


        public UpdateInvoiceCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.Response.Quantity).NotEmpty().WithMessage("Quantity is required");
            RuleFor(C => C.Response.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.Response.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.Response.OrderID).NotEmpty().WithMessage("OrderID is required");
            RuleFor(C => C.Response.ItemID).NotEmpty().WithMessage("ItemID is required");


        }



    }

}
