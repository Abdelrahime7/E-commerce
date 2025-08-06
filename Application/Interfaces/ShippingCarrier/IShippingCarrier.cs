using Domain.Shipping.ShippingService;


namespace Application.Interfaces.ShippingCarrier
{
    public interface IShippingCarrier
    {
        Task <ShipmentResult>CreateShipmentAsync(ShipmentRequest Request);
        public Task<bool> CancelShipmentAsync(ShipmentRequest request);

        public Task<bool> ConfirmShipementRecieptAsync(ShipmentRequest request);
      
    }
}
