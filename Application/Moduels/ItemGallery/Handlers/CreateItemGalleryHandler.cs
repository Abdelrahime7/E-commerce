
using Application.Moduels.ItemGallery.Commands;
using Domain.Interface;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.ItemGallery.Handlers
{

    public class CreateItemGalleryHandler : CreatHandler<CreateItemGalleryCommand>
    {
        public CreateItemGalleryHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<CreateItemGalleryHandler>logger) : base(mapper, repository, logger)
        {

        }

    }

}
