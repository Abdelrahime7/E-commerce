using Application.DTOs.Authetnication;
using Application.Interfaces.Specific;
using Application.Moduels.Customer.Handlers;
using MediatR;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Authentication.Commands.Commands;
using static Application.Moduels.Authentication.Queries.Queries;

namespace Application.Moduels.Authentication.Handlers
{
    public class LogOutHandler : IRequestHandler<LogoutCommand, LogOutResult>
    {
       private readonly  IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogger<AuthenticateUserHandler> _logger;

        public LogOutHandler(IRefreshTokenRepository refreshTokenRepository,
            ILogger<AuthenticateUserHandler> logger)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _logger= logger;
        }

        public async Task<LogOutResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var storedToken = await _refreshTokenRepository.GetRefrechTockenAsync(request.Request.RefreshToken);

            if (storedToken == null)
            {
                _logger.LogWarning("Logout failed: refresh token not found. Token: {Token}", request.Request.RefreshToken);
                return new LogOutResult { Success = false, Message = "Log out failed, token not found" };
            }
            storedToken.IsRevoked = true;
            storedToken.RevockedDate = DateTime.UtcNow;

            await _refreshTokenRepository.UpdateAsync(storedToken);
            _logger.LogInformation("User {UserId} logged out. Refresh token revoked at {Time}. Token: {Token}",
            storedToken.UserId,storedToken.RevockedDate, storedToken.Token);

            return new LogOutResult { Success = true, Message = "User logged out successfully. Refresh token revoked." };

        }
    }
}

