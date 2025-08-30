using Application.DTOs.Authetnication;
using MediatR;

namespace Application.Moduels.Authentication.Queries
{
    public class Queries
    {
        public record AuthenticateUserQuery(AuthenticationRequest Request) : IRequest<AuthResult>;

    }
}
