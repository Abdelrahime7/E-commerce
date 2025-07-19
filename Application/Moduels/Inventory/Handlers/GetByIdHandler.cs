using Application.DTOs.Inventory;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Inventory.Queries.Queries;

namespace Application.Moduels.Inventory.Handlers
{
   public class GetInventoryByIdHandler: GetByIdHander<GetInventoryByIdQuery, InventoryDto>
    {
        public GetInventoryByIdHandler(IMapper mapper,IInventoryRepository repository) :base (mapper, (IGenericRepository<IEntity>)repository)
        {
            
        }


        protected override int GetID(GetInventoryByIdQuery query) => query.Id;
      
    }
}
