using Application.DTOs.Item;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Item.Queries.Queries;

namespace Application.Moduels.Item.Handlers
{
   public class GetItemByIdHandler: GetByIdHander<GetItemByIdQuery, ItemDto>
    {
        public GetItemByIdHandler(IMapper mapper,IItemRepository repository
            ,ILogger<GetItemByIdHandler>logger) :base (mapper, (IGenericRepository<IEntity>)repository, logger)
        {
            
        }


        protected override int GetID(GetItemByIdQuery query) => query.Id;
      
    }
}
