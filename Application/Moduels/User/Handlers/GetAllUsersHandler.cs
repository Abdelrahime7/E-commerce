using Application.DTOs.User;
using Application.Interface;
using Application.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Microsoft.Extensions.Logging;
using static Application.Moduels.User.Queries.Queries;

namespace Application.Moduels.User.Handlers
{
    public class GetAllUsersHandler : GetAllHandler<GetAllUsersQuery, UserDto>
    {
        public GetAllUsersHandler(IMapper mapper, IUserRepository repository
            ,ILogger<GetAllUsersHandler> logger) : base(mapper, (IGenericRepository<IEntity>)repository,logger)
        {
        }
    }
}
