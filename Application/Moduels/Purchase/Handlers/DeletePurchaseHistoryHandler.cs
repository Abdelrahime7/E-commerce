using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Purchase.Commands;
using Domain.Interface;

namespace Application.Moduels.PurchaseHistory.Handlers
{
    public class DeletePurchaseHistoryHandler :DeleteHandler<DeletePurchaseCommand>
    {
        public DeletePurchaseHistoryHandler( IPurchaseRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeletePurchaseCommand command)=>command.ID;





    }





}

