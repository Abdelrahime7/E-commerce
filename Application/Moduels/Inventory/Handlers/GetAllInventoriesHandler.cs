
using Application.DTOs.Inventory;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Inventory.Queries.Queries;

namespace Application.Moduels.Customer.Handlers
{
    public class GetAllInventoriesHandler : GetAllHandler<GetAllInventoriesQuery, InventoryDto>
    {
        public GetAllInventoriesHandler(IMapper mapper, IInventoryRepository repository
            ,ILogger<GetAllHandler<GetAllInventoriesQuery, InventoryDto>> logger) : base(mapper, (IGenericRepository<IEntity>)repository, logger)
        {
        }
    }
}
