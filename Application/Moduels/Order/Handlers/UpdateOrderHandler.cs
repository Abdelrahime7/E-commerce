using Application.DTOs.Order;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Order.Commands;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Order.Handlers
{
    public class UpdateOrderHandler : UpdateHandler<UpdateOrderCommand, OrderDto>
    {
        public UpdateOrderHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateOrderHandler>logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdateOrderCommand command) => command.Request.Id;
       
    }





}

