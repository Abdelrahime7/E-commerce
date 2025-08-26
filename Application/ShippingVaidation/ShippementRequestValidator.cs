using Domain.Shipping.ShippingService;
using FluentValidation;

namespace Application.ShippingVaidation
{
    public class ShippementRequestValidator:AbstractValidator<ShipmentRequest>
    {
        public ShippementRequestValidator()
        {
            RuleFor(S => S.OrderId).NotEqual(0).NotEmpty().WithMessage("OrderID is required");
            RuleFor(S => S.ShippingAddress).NotEmpty().WithMessage("ShippingAddress is required");
            RuleFor(S => S.Items).NotEmpty().WithMessage("Items is required");
            RuleFor(S => S.Carrier).NotEmpty().WithMessage("Carrier is required");

        }

    }

}
