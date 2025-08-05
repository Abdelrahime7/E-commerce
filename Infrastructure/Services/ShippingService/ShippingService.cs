using Application.Interface;
using Application.Interfaces.Iservices;
using Application.Interfaces.ShippingCarrier;
using Domain.Services.ShippingService;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;

namespace Infrastructure.Services.ShippingService
{

    public class ShippingService : IShippingService
    {
        private readonly IShippingCarrier _shippingCarrier;
        

        public ShippingService(IShippingCarrier shippingCarrier)
        {
            _shippingCarrier = shippingCarrier;
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
        }



    }








