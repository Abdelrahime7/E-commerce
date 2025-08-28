using AutoMapper;

using Domain.Interface;
using Application.Moduels.Purchase.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Purchase;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Purchase.Handlers
{
    public class UpdatePurchaseHandler : UpdateHandler<UpdatePurchaseCommand, PurchasHistoryDto>
    {
        public UpdatePurchaseHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdatePurchaseHandler> logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdatePurchaseCommand command) => command.request.Id;
       
    }





}

