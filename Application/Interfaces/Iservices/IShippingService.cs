

using Domain.Shipping.ShippingService;

namespace Application.Interfaces.Iservices
{
    public interface IShippingService
    {
        public  Task<ShipmentResult> CreateShipmentAsync(ShipmentRequest request);
    }

}
