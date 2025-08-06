using Application.Interface;
using Domain.entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.specific_Repo
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
      
        private readonly DbSet<Inventory> _dbSet;

        public InventoryRepository(DbSet<Inventory> dbSet, AppDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Inventory>();
        }

        public async Task<Inventory> GetByItemIDaAsync(int ID) =>
         await _dbSet.FirstOrDefaultAsync(i => i.ItemID == ID);


    }
}
