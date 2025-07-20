using Application.DTOs.User;
using MediatR;

namespace Application.Moduels.User.Queries
{
     public class Queries
    {
        public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
        public record GetAllUsersQuery : IRequest<IReadOnlyCollection<UserDto>>;

    }
}
