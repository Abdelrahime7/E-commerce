using Application.DTOs.Order;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Order.Queries.Queries;

namespace Application.Moduels.Order.Handlers
{
    public class GetAllOrdersHandler : GetAllHandler<GetAllOrdersQuery, OrderDto>
    {
        public GetAllOrdersHandler(IMapper mapper,IOrderRepository repository) : base(mapper, (IGenericRepository<IEntity>)repository)
        {
        }
    }
}
