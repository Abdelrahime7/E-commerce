

namespace Application.Interfaces.Iservices
{
    public interface IInventoryService
    {
        Task<bool> IsAvailableAsync(Guid ItemId, int quantity);
        Task ReserveAsync(Guid ItemId, int quantity);
    }

}
