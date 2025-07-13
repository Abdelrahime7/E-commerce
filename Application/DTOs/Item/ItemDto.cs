using Domain.entities;
using Domain.Enums;

namespace Application.DTOs.Item
{
    public record ItemDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int InventoryDevision { get; set; }
        public int ItemQuantity { get; set; }

        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ProdDate { get; set; }
        public UnitTypes UnitType { get; set; }

    }


}