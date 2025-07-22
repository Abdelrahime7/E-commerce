using Application.Moduels.Sale.Commands;
using FluentValidation;

namespace Application.Moduels.Sale.Validators
{
    public class CrateSaleCommandValidator:AbstractValidator<CreateSaleCommand>
    {

        
        public CrateSaleCommandValidator()
        {
            RuleFor(C => C.saleDto.TotalFees).NotEmpty().WithMessage("Total Fees is required");
            RuleFor(C => C.saleDto.OrderId).NotEmpty().WithMessage("Order Id is required");
           

        }



    }

}
