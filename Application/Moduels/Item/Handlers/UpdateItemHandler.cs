using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Item.Commands;
using Application.DTOs.Item;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Item.Handlers
{
    public class UpdateItemHandler : UpdateHandler<UpdateItemCommand, ItemDto>
    {
        public UpdateItemHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateItemHandler>logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdateItemCommand command) => command.Response.Id;
       
    }





}

