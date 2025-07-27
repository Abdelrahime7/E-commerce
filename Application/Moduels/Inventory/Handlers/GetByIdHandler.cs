using Application.DTOs.Inventory;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Inventory.Queries.Queries;

namespace Application.Moduels.Inventory.Handlers
{
   public class GetInventoryByIdHandler: GetByIdHander<GetInventoryByIdQuery, InventoryDto>
    {
        public GetInventoryByIdHandler(IMapper mapper,IInventoryRepository repository,
            ILogger<GetByIdHander<GetInventoryByIdQuery, InventoryDto>> logger) :base (mapper, (IGenericRepository<IEntity>)repository, logger)
        {
            
        }


        protected override int GetID(GetInventoryByIdQuery query) => query.Id;
      
    }
}
