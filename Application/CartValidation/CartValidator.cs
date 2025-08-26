
using Domain.Cart;
using FluentValidation;

namespace Application.CartValidation
{
    public class CartValidator : AbstractValidator<Cart>
    {


        public CartValidator()
        {

            RuleFor(C => C.Id).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.itemDetaills).NotEmpty().WithMessage("itemDetaills is required");
            RuleFor(C => C.clientInfo).NotNull().NotEmpty().WithMessage("clientInfo is required");
            RuleFor(C => C.Date).NotEmpty().WithMessage("Date is required");
           
        }

    }
}

