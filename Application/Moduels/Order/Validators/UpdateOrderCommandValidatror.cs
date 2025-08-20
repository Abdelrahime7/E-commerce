using Application.Moduels.Order.Commands;
using FluentValidation;

namespace Application.Moduels.Order.Validators
{
    public class UpdateOrderCommandValidatror : AbstractValidator<UpdateOrderCommand>
    {


        public UpdateOrderCommandValidatror()
        {
            RuleFor(C => C.Request.Id).NotEmpty().WithMessage("Order id  is required");
            RuleFor(C => C.Request.Status).NotEmpty().WithMessage("Order Status is required");
            RuleFor(C => C.Request.Total).NotEmpty().WithMessage("Total is required");
            RuleFor(C => C.Request.CustomerId).NotEmpty().WithMessage("Customer Id is required");


        }



    }

}
