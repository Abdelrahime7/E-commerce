using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.DTOs.User;
using Application.Moduels.User.Commands;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.User.Handlers
{
    public class UpdateUserHandler : UpdateHandler<UpdateUserCommand, UserDto>
    {
        public UpdateUserHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdateUserHandler> logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdateUserCommand command) => command.request.Id;
       
    }





}

