using Application.DTOs.ItemGallery;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.ItemGallery.Queries.Queries;

namespace Application.Moduels.ItemGallery.Handlers
{
    public class GetAllItemsGalleryHandler : GetAllHandler<GetAllItemsGalleryQuery, ItemGalleryDto>
    {
        public GetAllItemsGalleryHandler(IMapper mapper, IItemGalleryRepository repository,
            ILogger<GetAllItemsGalleryHandler> logger) : base(mapper, (IGenericRepository<IEntity>)repository,logger)
        {
        }
    }
}
