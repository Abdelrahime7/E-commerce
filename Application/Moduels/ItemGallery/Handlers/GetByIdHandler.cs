using Application.DTOs.ItemGallery;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.ItemGallery.Queries.Queries;

namespace Application.Moduels.ItemGallery.Handlers
{
   public class GetItemGalleryByIdHandler: GetByIdHander<GetItemGalleryByIdQuery, ItemGalleryDto>
    {
        public GetItemGalleryByIdHandler(IMapper mapper,IItemGalleryRepository repository) :base (mapper, (IGenericRepository<IEntity>)repository)
        {
            
        }


        protected override int GetID(GetItemGalleryByIdQuery query) => query.Id;
      
    }
}
