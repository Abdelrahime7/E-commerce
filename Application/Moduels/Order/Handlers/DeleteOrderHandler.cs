

using Domain.Interface;
using Application.Moduels.Order.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.Order.Handlers
{
    public class DeleteOrderHandler :DeleteHandler<DeleteOrderCommand>
    {
        public DeleteOrderHandler( IOrderRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteOrderCommand command)=>command.ID;





    }





}

