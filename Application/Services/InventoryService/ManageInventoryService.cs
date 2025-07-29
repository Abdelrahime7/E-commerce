using Application.Interface;
using Application.Interfaces.Iservices;
using Microsoft.Extensions.Logging;

namespace Application.Services.InventoryService
{
    public class ManageInventoryService : IInventoryService
    {
        private readonly ILogger<ManageInventoryService> _logger;
        private readonly IInventoryRepository  _repository;
        public ManageInventoryService(IInventoryRepository repository,
            ILogger<ManageInventoryService> logger)
        {
            _logger = logger;
            _repository=repository;
        }

        public  async Task<bool>  IsAvailableAsync(int ItemId, int quantity)
        {
            var item = await _repository.GetByIDAsync(ItemId);
            if (item != null)
            {
            return item.ItemQuantity>=quantity;   
            }
            _logger.LogWarning("Item {ItemId} has insufficient quantity. Requested: {Requested}, Available: {Available}",
                return false;

        }

        public Task ReserveAsync(Guid ItemId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
