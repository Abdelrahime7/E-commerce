using Application.Moduels.Purchase.Commands;
using FluentValidation;

namespace Application.Moduels.Purchase.Validators
{
    public class CratePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>
    {

        
        public CratePurchaseCommandValidator()
        {
            RuleFor(C => C.purhcaseDto.OrderId).NotEmpty().WithMessage("Order Id is required");
            RuleFor(C => C.purhcaseDto.CustomerId).NotEmpty().WithMessage("Customer Id is required");
          

        }



    }


}
