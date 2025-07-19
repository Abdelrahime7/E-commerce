
using Domain.Interface;
using Application.Moduels.Person.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.Person.Handlers
{
    public class DeletePersonHandler :DeleteHandler<DeletePersonCommand>
    {
        public DeletePersonHandler( IPersonRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeletePersonCommand command)=>command.ID;





    }





}

