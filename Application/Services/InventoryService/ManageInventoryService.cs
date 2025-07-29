using Application.Interfaces.Iservices;

namespace Application.Services.InventoryService
{
    public class ManageInventoryService : IInventoryService
    {
        public Task<bool> IsAvailableAsync(Guid ItemId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task ReserveAsync(Guid ItemId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
