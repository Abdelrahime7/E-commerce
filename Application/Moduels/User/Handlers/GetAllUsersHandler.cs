using Application.DTOs.User;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using static Application.Moduels.User.Queries.Queries;

namespace Application.Moduels.User.Handlers
{
    public class GetAllUsersHandler : GetAllHandler<GetAllUsersQuery, UserDto>
    {
        public GetAllUsersHandler(IMapper mapper, IUserRepository repository) : base(mapper, (IGenericRepository<IEntity>)repository)
        {
        }
    }
}
