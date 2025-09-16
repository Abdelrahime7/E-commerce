using Application.Interfaces.ShippingCarrier;
using Domain.Shipping.ShippingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.ShippingService
{
    public class ShippingCarrier : IShippingCarrier
    {
        public Task<bool> CancelShipmentAsync(ShipmentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConfirmShipementRecieptAsync(ShipmentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ShipmentResult> CreateShipmentAsync(ShipmentRequest Request)
        {
            throw new NotImplementedException();
        }
    }
}
