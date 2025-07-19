using Application.DTOs.Customer;
using Application.DTOs.Inventory;
using MediatR;


namespace Application.Moduels.Inventory.Commands
{
  
     public record CreateInventoryCommand(InventoryDto inventoryDto) : IRequest<int>;

    public record UpdateInventoryCommand(InventoryResponse Response) : IRequest<InventoryDto>;
    public record DeleteInventoryCommand(int ID) : IRequest<bool>;

}
