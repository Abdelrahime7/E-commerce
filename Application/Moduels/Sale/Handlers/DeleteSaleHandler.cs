
using Domain.Interface;
using Application.Moduels.Sale.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.Sale.Handlers
{
    public class DeleteSaleHandler :DeleteHandler<DeleteSaleCommand>
    {
        public DeleteSaleHandler( ISaleRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteSaleCommand command)=>command.ID;





    }





}

