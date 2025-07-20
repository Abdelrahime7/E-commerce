using Application.DTOs.Invoice;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Invoice.Queries.Queries;

namespace Application.Moduels.Customer.Handlers
{
    public class GetAllInvoicesHandler : GetAllHandler<GetAllInvoicesQuery, InvoiceDto>
    {
        public GetAllInvoicesHandler(IMapper mapper,  IInvoiceRepository repository) : base(mapper, (IGenericRepository<IEntity>)repository)
        {
        }
    }
}
