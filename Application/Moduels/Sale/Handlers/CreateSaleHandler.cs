using AutoMapper;
using Domain.Interface;
using Application.Moduels.Sale.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.Sale.Handlers
{

    public class CreateSaleHandler : CreatHandler<CreateSaleCommand>
    {
        public CreateSaleHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<CreateSaleHandler> logger) : base(mapper, repository, logger)
        {

        }

    }



}
