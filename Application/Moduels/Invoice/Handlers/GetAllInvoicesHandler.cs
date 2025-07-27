using Application.DTOs.Invoice;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Invoice.Queries.Queries;

namespace Application.Moduels.Customer.Handlers
{
    public class GetAllInvoicesHandler : GetAllHandler<GetAllInvoicesQuery, InvoiceDto>
    {
        public GetAllInvoicesHandler(IMapper mapper,  IInvoiceRepository repository,
            ILogger<GetAllHandler<GetAllInvoicesQuery, InvoiceDto>> logger) : base(mapper, (IGenericRepository<IEntity>)repository, logger)
        {
        }
    }
}
