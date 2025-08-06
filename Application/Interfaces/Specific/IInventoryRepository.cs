

using Application.Interfaces.Generic;
using Domain.entities;

namespace Application.Interface
{
    public interface IInventoryRepository: IGenericRepository<Inventory>
    {

        Task<Inventory> GetByItemIDaAsync(int ID);

    }
}
