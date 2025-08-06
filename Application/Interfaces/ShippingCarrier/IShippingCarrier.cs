using Domain.Shipping.ShippingService;


namespace Application.Interfaces.ShippingCarrier
{
    public interface IShippingCarrier
    {
        Task <ShipmentResult>CreateShipmentAsync(ShipmentRequest Request);
    }
}
