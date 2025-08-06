using Domain.entities;
using System.Collections.Generic;

namespace Domain.Shipping.ShippingService
{
    public class ShipmentRequest
    {
        public string OrderId { get; set; }
        public string ShippingAddress { get; set; }
        public List<Item> Items { get; set; }
        public string Carrier { get; set; }
    }
}