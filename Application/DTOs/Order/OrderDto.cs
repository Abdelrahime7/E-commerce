using Domain.entities;
using Domain.Enums;

namespace Application.DTOs.Order

{
    public record OrderDto
    {

        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
        public  Domain.entities. Customer Customer { get; set; }
        public  PurchaseHistory PurchaseHistory { get; set; }
        public  Domain.entities.Sale Sale { get; set; }


        public ICollection<Domain.entities.Invoice> invoices { get; set; }=new List<Domain.entities.Invoice>();
       


    }


}