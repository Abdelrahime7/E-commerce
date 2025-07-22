namespace Application.DTOs.Purchase
{
    public record PurchasHistoryDto
    {
        
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        
    }

}
