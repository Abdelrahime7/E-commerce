using Application.Moduels.Purchase.Commands;
using FluentValidation;

namespace Application.Moduels.Purchase.Validators
{
    public class UpdatePurchaseCommandValidator : AbstractValidator<UpdatePurchaseCommand>
    {


        public UpdatePurchaseCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.Response.OrderId).NotEmpty().WithMessage("Order Id is required");
            RuleFor(C => C.Response.CustomerId).NotEmpty().WithMessage("Customer Id is required");


        }



    }


}
