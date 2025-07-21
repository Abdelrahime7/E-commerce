using Application.Moduels.Item.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Specific.IunitOW;

namespace Application.Moduels.Item.Handlers
{
    public class DeleteItemHandler(IItemUnitOfWork unitOfWork) : DeleteHandler<SoftDeleteItemCommand>
    {
        private readonly IItemUnitOfWork _unitOfWork = unitOfWork;

        public override async Task<bool> Handle(SoftDeleteItemCommand request, CancellationToken cancellationToken)

        {
            var item = await _unitOfWork.ItemRepository.GetByIDAsync(request.ID);
            if (item != null)
            {
                await _unitOfWork.InventoryRepository.SoftDeleteAsync(item.Inventory.Id);
                await _unitOfWork.ItemRepository.SoftDeleteAsync(item.Id);
               return await _unitOfWork.SaveAsync() > 0;
            }

            return false;
        }
    }





}

