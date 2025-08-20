using Application.Moduels.Purchase.Commands;
using FluentValidation;

namespace Application.Moduels.Purchase.Validators
{
    public class UpdatePurchaseCommandValidator : AbstractValidator<UpdatePurchaseCommand>
    {


        public UpdatePurchaseCommandValidator()
        {
            RuleFor(C => C.request.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(C => C.request.OrderId).NotEmpty().WithMessage("Order Id is required");
            RuleFor(C => C.request.CustomerId).NotEmpty().WithMessage("Customer Id is required");


        }



    }


}
