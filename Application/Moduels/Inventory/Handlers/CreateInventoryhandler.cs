
using Application.Interfaces.Generic;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Inventory.Commands;
using Application.Moduels.Item.Commands;
using Application.Moduels.User.Commands;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Inventory.Handlers
{

    

    

        public class CreateInventoryHandler : CreatHandler<CreateInventoryCommand>
        {
            public CreateInventoryHandler(IMapper mapper, IGenericRepository<IEntity> repository,
                ILogger<CreatHandler<CreateInventoryCommand>> logger) : base(mapper, repository, logger)
            {

            }

        }




}

