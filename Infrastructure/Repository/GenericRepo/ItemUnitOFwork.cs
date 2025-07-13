
using Infrastructure.ADbContext;
using Application.Interface;
using Application.Interfaces.Specific.IunitOW;

namespace Infrastructure.Repository.GenericRepo
{
    public class ItemUnitOFwork(IInventoryRepository inventoryRepository, IItemRepository itemRepository,  AppDbContext appDbContext) : IItemUnitOfWork
    {
        
        private readonly AppDbContext _appDbContext = appDbContext;

        public IInventoryRepository InventoryRepository => inventoryRepository;

        public IItemRepository ItemRepository => itemRepository;

        public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();

        public void Dispose()=>_appDbContext.Dispose();

        
    }
}
