using Application.DTOs.Order;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Order.Queries.Queries;

namespace Application.Moduels.Order.Handlers
{
   public class GetOrderByIdHandler: GetByIdHander<GetOrderByIdQuery, OrderDto>
    {
        public GetOrderByIdHandler(IMapper mapper,IOrderRepository repository,
            ILogger<GetOrderByIdHandler>logger) :base (mapper, (IGenericRepository<IEntity>)repository, logger)
        {
            
        }


        protected override int GetID(GetOrderByIdQuery query) => query.Id;
      
    }
}
