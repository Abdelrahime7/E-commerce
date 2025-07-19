using AutoMapper;

using Domain.Interface;
using Application.Moduels.User.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Generic;
using Application.Interface;

namespace Application.Moduels.User.Handlers
{
    public class DeleteUserHandler :DeleteHandler<DeleteUserCommand>
    {
        public DeleteUserHandler( IUserRepository repository) : base((IGenericRepository<IEntity>)repository)
    
        {
        }

        protected override int GetID(DeleteUserCommand command)=>command.ID;





    }





}

