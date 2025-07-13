using Application.Interface;
using Domain.Interfaces.Generic;


namespace Application.Interfaces.Specific.IunitOW
{
    public interface IItemUnitOfWork :IUnitOfWork
    {
        public IInventoryRepository InventoryRepository { get; }
        public IItemRepository ItemRepository { get; }



    }
}
