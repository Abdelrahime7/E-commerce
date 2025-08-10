using Application.Interfaces.Iservices;
using Application.Interfaces.ShippingCarrier;
using Domain.Enums;
using Domain.Shipping.ShippingService;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Services.ShippingService
{

    public class ShippingService : IShippingService
    {
        private readonly ILogger<ShippingService> _logger;
        private readonly IShippingCarrier _shippingCarrier;
        private readonly IInventoryService _inventoryService;

        public ShippingService(IShippingCarrier shippingCarrier ,
            IInventoryService inventoryService,
            ILogger<ShippingService> logger)
        {
            _shippingCarrier = shippingCarrier;
            _inventoryService = inventoryService;
            _logger= logger;
        }

            public async Task<ShipmentResult> CreateShipmentAsync(ShipmentRequest request)
        {
            _logger.LogInformation("Creating shipment for request: {@ShipmentRequest}", request);
            try
                {
                    var carrierResponse = await _shippingCarrier.CreateShipmentAsync(request);

                    var result= new ShipmentResult
                    {
                        ShipmentId = carrierResponse.ShipmentId,
                        TrackingNumber = carrierResponse.TrackingNumber,
                        EstimatedDeliveryDate = carrierResponse.EstimatedDeliveryDate,
                        LabelUrl = carrierResponse.LabelUrl
                    };
                _logger.LogInformation("Shipment created successfully: {@ShipmentResult}", result);
                return result;
                }
                catch (Exception ex)
                {
                _logger.LogError(ex, "Failed to create shipment for request: {@ShipmentRequest}", request);
                throw new ShippingException("Shipment creation failed", ex);
                }
            }

        public async Task<bool> CancelShipmentAsync(ShipmentRequest request) 
        {
            _logger.LogInformation("Attempting to cancel shipment for request: {@ShipmentRequest}", request);

            if (await _shippingCarrier.CancelShipmentAsync(request))
            {
                _logger.LogInformation("Shipment canceled successfully. Updating inventory...");
                foreach ( var item in request.Items)
                {
                      await  _inventoryService.UpdateInventory
                        (item.itemID, item.Quantity, EnOperation.Decrease);
                    _logger.LogInformation("Inventory decreased for ItemID: {ItemID}, Quantity: {Quantity}", item.itemID, item.Quantity);
                }
                return true;
            }
            _logger.LogWarning("Shipment cancellation failed for request: {@ShipmentRequest}", request);
            return false;
        }

        public async Task<bool> ConfirmShipementRecieptAsync(ShipmentRequest request)
        {
            _logger.LogInformation("Confirming shipment receipt for request: {@ShipmentRequest}", request);
            if (await _shippingCarrier.ConfirmShipementRecieptAsync(request))
               
            {
                _logger.LogInformation("Shipment receipt confirmed. Updating inventory...");
                foreach (var item in request.Items)
                    {
                        await _inventoryService.UpdateInventory
                              (item.itemID, item.Quantity, EnOperation.Increase);
                        _logger.LogInformation("Inventory increased for ItemID: {ItemID}, Quantity: {Quantity}", item.itemID, item.Quantity);
                     }
                 return true ;
             }
            _logger.LogWarning("Shipment receipt confirmation failed for request: {@ShipmentRequest}", request);
            return false;
            
        }


        }




    }








