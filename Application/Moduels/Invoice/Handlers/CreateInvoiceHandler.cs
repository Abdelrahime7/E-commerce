using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Invoice.Commands;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.Invoice.Handlers
{

    public class CreateInvoiceHandler : CreatHandler<CreateInvoiceCommand>
    {
        public CreateInvoiceHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<CreatHandler<CreateInvoiceCommand>> logger) : base(mapper, repository, logger)
        {

        }

    }





}
