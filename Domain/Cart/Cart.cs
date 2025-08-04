using System;
using System.Collections.Generic;


namespace Domain.Cart
{
    public class Cart
    {
        public Guid Id { get; set; }
        public ICollection<ItemDetaills> itemDetaills { get; set; }
        public ClientInfo clientInfo { get; set; }
        public DateTime Date { get; set; }

    }
}
