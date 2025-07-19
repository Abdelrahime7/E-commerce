using Application.DTOs.User;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.User.Queries.Queries;

namespace Application.Moduels.User.Handlers
{
   public class GetUserByIdHandler: GetByIdHander<GetUserByIdQuery, UserDto>
    {
        public GetUserByIdHandler(IMapper mapper,IUserRepository repository) :base (mapper, (IGenericRepository<IEntity>)repository)
        {
            
        }


        protected override int GetID(GetUserByIdQuery query) => query.Id;
      
    }
}
