using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.ItemGallery.Commands;
using Application.DTOs.ItemGallery;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.ItemGallery.Handlers
{
    public class UpdateItemGalleryHandler : UpdateHandler<UpdateItemGalleryCommand, ItemGalleryDto>
    {
        public UpdateItemGalleryHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateItemGalleryHandler>logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdateItemGalleryCommand command) => command.request.Id;
       
    }





}

