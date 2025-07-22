using Application.Moduels.Sale.Commands;
using FluentValidation;

namespace Application.Moduels.Sale.Validators
{
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {


        public UpdateSaleCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.TotalFees).NotEmpty().WithMessage("Total Fees is required");
            RuleFor(C => C.Response.OrderId).NotEmpty().WithMessage("Order Id is required");


        }



    }

}
