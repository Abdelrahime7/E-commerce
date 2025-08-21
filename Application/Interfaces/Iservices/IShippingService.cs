

using Domain.Shipping.ShippingService;

namespace Application.Interfaces.Iservices
{
    public interface IShippingService
    {
        Task<ShipmentResult> CreateShipmentAsync(ShipmentRequest Request);
        public Task<bool> CancelShipmentAsync(ShipmentRequest request);
        public Task<bool> ConfirmShipementRecieptAsync(ShipmentRequest request);
    }

}
