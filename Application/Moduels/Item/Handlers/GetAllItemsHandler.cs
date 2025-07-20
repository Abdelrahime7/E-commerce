using Application.DTOs.Item;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Item.Queries.Queries;

namespace Application.Moduels.Item.Handlers
{
    public class GetAllItemsHandler : GetAllHandler<GetAllItemsQuery, ItemDto>
    {
        public GetAllItemsHandler(IMapper mapper, IItemRepository  repository) : base(mapper, (IGenericRepository<IEntity>)repository)
        {
        }
    }
}
