using Application.DTOs.Invoice;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Invoice.Queries.Queries;

namespace Application.Moduels.Invoice.Handlers
{
   public class GetInvoiceByIdHandler: GetByIdHander<GetInvoiceByIdQuery, InvoiceDto>
    {
        public GetInvoiceByIdHandler(IMapper mapper,IInvoiceRepository repository) :base (mapper, (IGenericRepository<IEntity>)repository)
        {
            
        }


        protected override int GetID(GetInvoiceByIdQuery query) => query.Id;
      
    }
}
