using System;

namespace Domain.Shipping.ShippingService
{
    public class ShipmentResult
    {
        public int ShipmentId { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string LabelUrl { get; set; } // Optional: for printing
    }
}