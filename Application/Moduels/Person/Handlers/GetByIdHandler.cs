using Application.DTOs.Person;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Person.Queries.Queries;

namespace Application.Moduels.Person.Handlers
{
   public class GetPersonByIdHandler: GetByIdHander<GetPersonByIdQuery, PersonDto>
    {
        public GetPersonByIdHandler(IMapper mapper,IPersonRepository repository,
            ILogger<GetPersonByIdHandler>logger) :base (mapper, (IGenericRepository<IEntity>)repository, logger)
        {
            
        }


        protected override int GetID(GetPersonByIdQuery query) => query.Id;
      
    }
}
