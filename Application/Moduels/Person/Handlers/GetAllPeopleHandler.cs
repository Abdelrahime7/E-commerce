
using Application.DTOs.Person;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Person.Queries.Queries;

namespace Application.Moduels.People.Handlers
{
    public class GetAllPeopleHandler : GetAllHandler<GetAllPeopleQuery, PersonDto>
    {
        public GetAllPeopleHandler(IMapper mapper, IPersonRepository repository,
            ILogger<GetAllPeopleHandler>logger) : base(mapper, (IGenericRepository<IEntity>)repository, logger)
        {
        }
    }
}
