using Application.Moduels.Item.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Specific.IunitOW;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Item.Handlers
{
    public class DeleteItemHandler(IItemUnitOfWork unitOfWork, ILogger<DeleteItemHandler> logger) : DeleteHandler<SoftDeleteItemCommand>
    {
        private readonly IItemUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<DeleteItemHandler> _logger = logger;

        public override async Task<bool> Handle(SoftDeleteItemCommand request, CancellationToken cancellationToken)

        {
            try
            {
                _logger.LogInformation("Attempting to soft delete item with ID {ItemId}", request.ID);

                var item = await _unitOfWork.ItemRepository.GetByIDAsync(request.ID);
                if (item != null)
                {
                    _logger.LogInformation("Item found. Proceeding to soft delete inventory ID {InventoryId}", item.Inventory.Id);

                    await _unitOfWork.InventoryRepository.SoftDeleteAsync(item.Inventory.Id);
                    await _unitOfWork.ItemRepository.SoftDeleteAsync(item.Id);

                    var result = await _unitOfWork.SaveAsync() > 0;
                    _logger.LogInformation("Soft delete completed for item ID {ItemId}. Save result: {Result}", item.Id, result);

                    return result;
                }
                else
                {
                    _logger.LogWarning("Item with ID {ItemId} not found. Soft delete aborted.", request.ID);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while attempting to soft delete item with ID {ItemId}", request.ID);
                throw;
            }

            return false;


        }

    }



}

