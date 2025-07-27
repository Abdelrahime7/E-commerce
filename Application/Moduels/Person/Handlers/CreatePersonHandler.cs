using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Person.Commands;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.Person.Handlers
{


    public class CreatePersonHandler : CreatHandler<CreatePersonCommand>
    {
        public CreatePersonHandler(IMapper mapper, IGenericRepository<IEntity> repository,
            ILogger<CreatePersonHandler>logger) : base(mapper, repository, logger)
        {


        }

    }




}
