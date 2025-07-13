
using AutoMapper;
using Application.Moduels.Inventory.Commands;
using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Generic;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.User.Commands;
using Application.Moduels.Item.Commands;

namespace Application.Moduels.Inventory.Handlers
{

    

    

        public class CreateInventoryHandler : CreatHandler<CreateInventoryCommand>
        {
            public CreateInventoryHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
            {

            }

        }




}

