using Domain.Services.ShippingService;


namespace Application.Interfaces.ShippingCarrier
{
    public interface IShippingCarrier
    {
        Task <ShipmentResult>CreateShipmentAsync(ShipmentRequest Request);
    }
}
