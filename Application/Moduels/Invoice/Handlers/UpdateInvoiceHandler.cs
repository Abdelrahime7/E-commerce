using Application.DTOs.Invoice;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Invoice.Commands;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Invoice.Handlers
{
    public class UpdateInvoiceHandler : UpdateHandler<UpdateInvoiceCommand, InvoiceDto>
    {
        public UpdateInvoiceHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateHandler<UpdateInvoiceCommand, InvoiceDto>> logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdateInvoiceCommand command) => command.Response.Id;
       
    }





}

