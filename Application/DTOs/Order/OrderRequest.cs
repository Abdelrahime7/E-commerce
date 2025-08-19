using Domain.entities;
using Domain.Enums;

namespace Application.DTOs.Order

{
    public record OrderRequest
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }

        

    }


}