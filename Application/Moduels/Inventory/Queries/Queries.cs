using Application.DTOs.Inventory;
using MediatR;


namespace Application.Moduels.Inventory.Queries
{
    public class Queries
    {
        public record GetInventoByIdQuery(int Id) : IRequest<InventoryDto>;
    }
}
