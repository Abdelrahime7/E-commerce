using Application.Interfaces.Specific;
using Domain.entities;
using Domain.Entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.specific_Repo
{
    public class DisacountsRepository : GenericRepository<Disacount>, IDisacountsRepository
    {
        private readonly DbSet<Disacount> _dbSet;

        public DisacountsRepository(AppDbContext context) :base(context)
        {
            _dbSet = context.Set<Disacount>();

        }
        public async Task<decimal> GetValuebytype(string type)
        {
            var value= await _dbSet.FirstOrDefaultAsync(d=>d.Type == type);
            if (value == null)
                return value.Percentag;
            else return 1m;
        }
    }
}
