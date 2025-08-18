using AutoMapper;

using Domain.Interface;
using Application.Moduels.Inventory.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Inventory;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Inventory.Handlers
{
    public class UpdateInventoryHandler : UpdateHandler<UpdateInventoryCommand, InventoryDto>
    {
        public UpdateInventoryHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateHandler<UpdateInventoryCommand, InventoryDto>> logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdateInventoryCommand command) => command.Request.Id;
       
    }





}

