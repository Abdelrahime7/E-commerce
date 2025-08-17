using Application.Moduels.Order.Commands;
using FluentValidation;

namespace Application.Moduels.Order.Validators
{
    public class CrateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {


        public CrateOrderCommandValidator()
        {
            RuleFor(C => C.OrderDto.Status).NotEmpty().WithMessage("Order Status is required");
            RuleFor(C => C.OrderDto.Total).NotEmpty().WithMessage("Total is required");
            RuleFor(C => C.OrderDto.Customer).NotEmpty().WithMessage("Customer Id is required");
         
        }



    }

}
