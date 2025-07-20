using Application.Moduels.Item.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Specific.IunitOW;

namespace Application.Moduels.Item.Handlers
{
    public class DeleteItemHandler(IItemUnitOfWork unitOfWork) : DeleteHandler<DeleteItemCommnd>
    {
        private readonly IItemUnitOfWork _unitOfWork = unitOfWork;

        public override async Task<bool> Handle(DeleteItemCommnd request, CancellationToken cancellationToken)

        {
            var item = await _unitOfWork.ItemRepository.GetByIDAsync(request.ID);
            if (item != null)
            {
                await _unitOfWork.InventoryRepository.DeleteAsync(item.Inventory.Id);
                await _unitOfWork.ItemRepository.DeleteAsync(item.Id);
                return true;
            }

            return false;
        }
    }





}

