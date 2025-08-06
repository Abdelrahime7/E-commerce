

using Domain.Enums;

namespace Application.Interfaces.Iservices
{
    public interface IInventoryService
    {
        Task<bool> IsAvailableAsync(int ItemId, int quantity);
        Task ReserveAsync(int ItemId, int quantity);

        Task UpdateInventory(int ItemId, int quantity,EnOperation operation );
    }

}
