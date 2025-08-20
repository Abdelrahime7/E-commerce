using Domain.entities;

namespace Application.DTOs.Purchase
{
    public record PurchasHistoryRequest
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        
    }

}
