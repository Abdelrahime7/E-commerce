using Application.Moduels.Order.Commands;
using FluentValidation;

namespace Application.Moduels.Order.Validators
{
    public class UpdateOrderCommandValidatror : AbstractValidator<UpdateOrderCommand>
    {


        public UpdateOrderCommandValidatror()
        {
            RuleFor(C => C.Response.Id).NotEmpty().WithMessage("Order id  is required");
            RuleFor(C => C.Response.Status).NotEmpty().WithMessage("Order Status is required");
            RuleFor(C => C.Response.Total).NotEmpty().WithMessage("Total is required");
            RuleFor(C => C.Response.CustomerId).NotEmpty().WithMessage("Customer Id is required");


        }



    }

}
