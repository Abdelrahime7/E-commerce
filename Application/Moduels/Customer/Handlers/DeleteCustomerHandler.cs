using AutoMapper;

using Domain.Interface;
using Application.Moduels.Customer.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.Customer.Handlers
{
    public class DeleteCustomerHandler :DeleteHandler<DeleteCustomerCommand>
    {
        public DeleteCustomerHandler( ICustomerRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteCustomerCommand command)=>command.ID;





    }





}

