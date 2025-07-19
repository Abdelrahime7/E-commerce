using AutoMapper;

using Domain.Interface;
using Application.Moduels.Invoice.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.Invoice.Handlers
{
    public class DeleteInvoiceHandler :DeleteHandler<DeleteInvoiceCommand>
    {
        public DeleteInvoiceHandler( IInvoiceRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteInvoiceCommand command)=>command.ID;





    }





}

