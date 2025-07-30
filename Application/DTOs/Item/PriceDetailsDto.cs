namespace Application.DTOs.Item
{
    public struct PriceDetailsDto
    {
      
            public decimal UnitPrice { get; set; }
            public decimal Discount { get; set; }
            public int  Quantity { get; set; }
            public decimal Tax { get; set; }
            public decimal FinalPrice { get; set; }
       

    }
}