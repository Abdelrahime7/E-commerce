
using Domain.Cart;
using FluentValidation;

namespace Application.CartValidation
{
    public partial class ClientInfoValidator
    {
        public class ItemDetaillsValidator : AbstractValidator<ItemDetaills>
        {


            public ItemDetaillsValidator()
            {
                RuleFor(I => I.Id).NotEmpty().WithMessage("Id is required");
                RuleFor(I => I.itemID).NotEqual(0).NotEmpty().WithMessage("LName is required");
                RuleFor(I => I.Quantity).NotEmpty().WithMessage("Quantity is required");
                RuleFor(I => I.price).NotEmpty().WithMessage("price is required");
                RuleFor(I => I.total).NotEmpty().WithMessage("total is required");

            }
        }

    }
}

