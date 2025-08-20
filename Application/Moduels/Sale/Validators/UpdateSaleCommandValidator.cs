using Application.Moduels.Sale.Commands;
using FluentValidation;

namespace Application.Moduels.Sale.Validators
{
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {


        public UpdateSaleCommandValidator()
        {
            RuleFor(C => C.request.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.request.TotalFees).NotEmpty().WithMessage("Total Fees is required");
            RuleFor(C => C.request.OrderId).NotEmpty().WithMessage("Order Id is required");


        }



    }

}
