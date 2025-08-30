using Application.DTOs.Authetnication;
using Application.Interfaces.Specific;
using MediatR;
using static Application.Moduels.Authentication.Commands.Commands;
using static Application.Moduels.Authentication.Queries.Queries;

namespace Application.Moduels.Authentication.Handlers
{
    public class LogOutHandler : IRequestHandler<LogoutCommand, LogOutResult>
    {
       private readonly  IRefreshTokenRepository _refreshTokenRepository;
        public LogOutHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LogOutResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var storedToken = await _refreshTokenRepository.GetRefrechTockenAsync(request.Request.RefreshToken);

            if (storedToken == null)
                return  new LogOutResult { Success=false,Message="Log out failed, token not found"};

            storedToken.IsRevoked = true;
            storedToken.RevockedDate = DateTime.UtcNow;

            await _refreshTokenRepository.UpdateAsync(storedToken);
            return new LogOutResult { Success = true, Message = "User logged out successfully. Refresh token revoked." };

        }
    }
}

