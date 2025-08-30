using Application.DTOs.Authetnication;
using MediatR;


namespace Application.Moduels.Authentication.Commands
{
    public static class Commands
    {
        public record LogoutCommand(LogOutRequest Request) : IRequest<LogOutResult>;

    }
}
