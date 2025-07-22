using Application.Moduels.Invoice.Commands;
using FluentValidation;

namespace Application.Moduels.Invoice.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateInvoiceCommand>
    {

        
        public CrateCommandValidator()
        {
            RuleFor(C => C.invoiceDto.Quantity).NotEmpty().WithMessage("Quantity is required");
            RuleFor(C => C.invoiceDto.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.invoiceDto.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.invoiceDto.OrderID).NotEmpty().WithMessage("OrderID is required");
            RuleFor(C => C.invoiceDto.ItemID).NotEmpty().WithMessage("ItemID is required");
               

        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.Response.Quantity).NotEmpty().WithMessage("Quantity is required");
            RuleFor(C => C.Response.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(C => C.Response.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.Response.OrderID).NotEmpty().WithMessage("OrderID is required");
            RuleFor(C => C.Response.ItemID).NotEmpty().WithMessage("ItemID is required");


        }



    }

    public class DeleteCommandValidator : AbstractValidator<SoftDeleteInvoiceCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
