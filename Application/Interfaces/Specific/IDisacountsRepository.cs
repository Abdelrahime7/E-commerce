

using Application.Interfaces.Generic;
using Domain.Entities;

namespace Application.Interfaces.Specific
{
    public interface IDisacountsRepository :IGenericRepository<Disacount>

    {
        Task<decimal> GetValuebytype(string type);
    }
}
