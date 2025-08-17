using AutoMapper;

using Domain.Interface;
using Application.Moduels.Customer.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Customer;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Customer.Handlers
{
    public class DeleteInventoryHandler : UpdateHandler<UpdateCustomerCommand,CustomerDto>
    {
        public DeleteInventoryHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<DeleteInventoryHandler> logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdateCustomerCommand command) => command.Request.ID;
       
    }





}

