using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Inventory.Commands;
using Domain.Interface;

namespace Application.Moduels.Inventory.Handlers
{
    public class DeleteInventoryHandler :DeleteHandler<DeleteInventoryCommand>
    {
        public DeleteInventoryHandler( IInventoryRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteInventoryCommand command)=>command.ID;





    }





}

