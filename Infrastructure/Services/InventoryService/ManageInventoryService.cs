using Application.Interface; 
using Application.Interfaces.Iservices;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Infrastructure.Services.InventoryService
{

    public class ManageInventoryService : IInventoryService

    {
        private static readonly ConcurrentDictionary<int, int> _reservedStock = new();

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
            _logger.LogInformation("check avaiable quantity of  Item with id : {id}   ", ItemId);

            var item = await _repository.GetByIDAsync(ItemId);
            if (item != null)
            {
            return item.ItemQuantity>=quantity;   
            }
            _logger.LogWarning("Item {item} has insufficient quantity. ", item);
                return false;

        }

        public async Task ReserveAsync(int ItemId, int quantity)
        {
            _logger.LogInformation("Attempting to reserve {Quantity} units of Item {ItemId}", quantity, ItemId);
            var availability = await IsAvailableAsync(ItemId, quantity);
            if (!availability)
            {

                _logger.LogWarning("Reservation failed for Item {ItemId}", ItemId);
                throw new InvalidOperationException("There is no available Quantity");
            }

            _reservedStock.AddOrUpdate(ItemId, quantity, (key, existing) => existing + quantity);
            _logger.LogInformation("Reserved {Quantity} units of Item {ItemId}", quantity, ItemId);

            var item = await _repository.GetByIDAsync(ItemId);
            item.ItemQuantity -= quantity;
            await _repository.UpdateAsync(item);
            _logger.LogInformation("Updated inventory for Item {ItemId}. Remaining quantity: {Remaining}", ItemId, item.ItemQuantity);

        }
    }
}
