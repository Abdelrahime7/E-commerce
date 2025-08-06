using Application.Interfaces.Iservices;
using Application.Interfaces.ShippingCarrier;
using Domain.Enums;
using Domain.Shipping.ShippingService;


namespace Infrastructure.Services.ShippingService
{

    public class ShippingService : IShippingService
    {
        private readonly IShippingCarrier _shippingCarrier;
        private readonly IInventoryService _inventoryService;

        public ShippingService(IShippingCarrier shippingCarrier , IInventoryService inventoryService)
        {
            _shippingCarrier = shippingCarrier;
            _inventoryService = inventoryService;
        }

            public async Task<ShipmentResult> CreateShipmentAsync(ShipmentRequest request)
            {
                try
                {
                    var carrierResponse = await _shippingCarrier.CreateShipmentAsync(request);

                    return new ShipmentResult
                    {
                        ShipmentId = carrierResponse.ShipmentId,
                        TrackingNumber = carrierResponse.TrackingNumber,
                        EstimatedDeliveryDate = carrierResponse.EstimatedDeliveryDate,
                        LabelUrl = carrierResponse.LabelUrl
                    };
                }
                catch (Exception ex)
                {
                 
                    throw new ShippingException("Shipment creation failed", ex);
                }
            }

        public async Task<bool> CancelShipmentAsync(ShipmentRequest request) 
        {

            if (await _shippingCarrier.CancelShipmentAsync(request))
            {
                foreach ( var item in request.Items)
                {
                  await  _inventoryService.UpdateInventory
                        (item.itemID, item.Quantity, EnOperation.Decrease);
                }
            }
            return false;
        }

        public async Task<bool> ConfirmShipementRecieptAsync(ShipmentRequest request)
        {
            if(await _shippingCarrier.ConfirmShipementRecieptAsync(request))
            
                {
                    foreach (var item in request.Items)
                    {
                        await _inventoryService.UpdateInventory
                              (item.itemID, item.Quantity, EnOperation.Increase);
                    }
                 
                }
                return false;
            
        }


        }




    }








