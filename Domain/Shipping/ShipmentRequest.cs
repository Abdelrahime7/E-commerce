using Domain.Cart;
using Domain.entities;
using System.Collections.Generic;

namespace Domain.Shipping.ShippingService
{
    public class ShipmentRequest
    {
        public int OrderId { get; set; }
        public string ShippingAddress { get; set; }
        public List<ItemDetaills> Items { get; set; }
        public string Carrier { get; set; }
    }
}