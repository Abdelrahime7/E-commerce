using System;

namespace Domain.Cart
{
   
        public struct ItemDetaills
            {
                public Guid Id { get; set; }
                public int itemID { get; set; }
                public decimal price { get; set; }
                public int Quantity { get; set; }
        public decimal total { get => price * Quantity;}
            }

}
