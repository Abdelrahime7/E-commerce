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
   public class GetItemGalleryByIdHandler: GetByIdHander<GetItemGalleryByIdQuery, ItemGalleryDto>
    {
        public GetItemGalleryByIdHandler(IMapper mapper,IItemGalleryRepository repository,
            ILogger<GetItemGalleryByIdHandler>logger) :base (mapper, (IGenericRepository<IEntity>)repository, logger)
        {
            
        }


        protected override int GetID(GetItemGalleryByIdQuery query) => query.Id;
      
    }
}
