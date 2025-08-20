using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Person.Commands;
using Application.DTOs.Person;
using Application.Interfaces.Generic;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Person.Handlers
{
    public class UpdatePersonHandler : UpdateHandler<UpdatePersonCommand, PersonDto>
    {
        public UpdatePersonHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<UpdatePersonHandler> logger) : base(mapper, repository, logger)
        {
        }

        protected override int GetId(UpdatePersonCommand command) => command.request.Id;
       
    }





}

