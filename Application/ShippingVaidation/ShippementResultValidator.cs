using Domain.Shipping.ShippingService;
using FluentValidation;

namespace Application.ShippingVaidation
{
    public class ShippementResultValidator : AbstractValidator<ShipmentResult>
    {
        public ShippementResultValidator()
        {
            RuleFor(S => S.ShipmentId).NotEqual(0).NotEmpty().WithMessage("ShipmentId is required");
            RuleFor(S => S.TrackingNumber).NotEmpty().WithMessage("TrackingNumber is required");
            RuleFor(S => S.EstimatedDeliveryDate).NotEmpty().WithMessage("EstimatedDeliveryDate is required");
            RuleFor(S => S.LabelUrl).NotEmpty().WithMessage("Carrier is required");

        }

    }

}
