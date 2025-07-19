
using Domain.Interface;
using Application.Moduels.ItemGallery.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.ItemGallery.Handlers
{
    public class DeleteItemGalleryHandler :DeleteHandler<DeleteItemGalleryCommand>
    {
        public DeleteItemGalleryHandler( IItemGalleryRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteItemGalleryCommand command)=>command.ID;





    }





}

