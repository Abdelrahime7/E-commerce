using AutoMapper;

using Domain.Interface;
using Application.Moduels.Sale.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Sale;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.sale.Handlers
{
    public class UpdateSaleHandler : UpdateHandler<UpdateSaleCommand,SaleDto>
    {
        public UpdateSaleHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateSaleHandler>logger) : base(mapper, repository, logger)
        {
        }        protected override int GetId(UpdateSaleCommand command) => command.request.Id;
       
    }





}

