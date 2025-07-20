
using Application.DTOs.Person;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.Person.Queries.Queries;

namespace Application.Moduels.People.Handlers
{
    public class GetAllPeopleHandler : GetAllHandler<GetAllPeopleQuery, PersonDto>
    {
        public GetAllPeopleHandler(IMapper mapper, IPersonRepository repository) : base(mapper, (IGenericRepository<IEntity>)repository)
        {
        }
    }
}
