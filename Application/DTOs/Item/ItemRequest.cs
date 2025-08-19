using Domain.entities;
using Domain.Enums;

namespace Application.DTOs.Item
{
    public record ItemRequest
    {
       public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ItemQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ProdDate { get; set; }
        public UnitTypes UnitType { get; set; }

    }


}