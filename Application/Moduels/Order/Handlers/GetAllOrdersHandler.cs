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
    public class GetAllOrdersHandler : GetAllHandler<GetAllOrdersQuery, OrderDto>
    {
        public GetAllOrdersHandler(IMapper mapper,IOrderRepository repository,
            ILogger<GetAllOrdersHandler>logger) : base(mapper, (IGenericRepository<IEntity>)repository, logger)
        {
        }
    }
}
