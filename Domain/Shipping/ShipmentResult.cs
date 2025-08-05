using System;

namespace Domain.Services.ShippingService
{
    public class ShipmentResult
    {
        public string ShipmentId { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string LabelUrl { get; set; } // Optional: for printing
    }
}