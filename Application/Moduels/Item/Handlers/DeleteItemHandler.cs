using AutoMapper;

using Domain.Interface;
using Application.Moduels.Item.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.Item.Handlers
{
    public class DeleteItemHandler :DeleteHandler<DeleteItemCommnd>
    {
        public DeleteItemHandler( IItemRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteItemCommnd command)=>command.ID;





    }





}

