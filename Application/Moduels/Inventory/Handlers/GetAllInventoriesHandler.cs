
using Application.DTOs.Inventory;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Inventory.Queries.Queries;

namespace Application.Moduels.Customer.Handlers
{
    public class GetAllInventoriesHandler : GetAllHandler<GetAllInventoriesQuery, InventoryDto>
    {
        public GetAllInventoriesHandler(IMapper mapper, IInventoryRepository repository) : base(mapper, (IGenericRepository<IEntity>)repository)
        {
        }
    }
}
