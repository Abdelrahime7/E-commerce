
using Application.DTOs.Authetnication;
using Application.Interface;
using Application.Interfaces.Iservices;
using Application.Interfaces.Specific;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Authentication.Queries.Queries;


namespace Application.Moduels.Customer.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogger<AuthenticateUserHandler> _logger;

        public AuthenticateUserHandler(IUserRepository userRepository,
            ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository,
            ILogger<AuthenticateUserHandler> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _refreshTokenRepository= refreshTokenRepository;
            _logger = logger;
        }




        public async Task<AuthResult> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start authentication for user: {Username}", request?.Request?.UserName);

            var user = await _userRepository.CheckUserAsync(request.Request);

            if (user is null)
            {
                _logger.LogWarning("Authentication failed for user: {Username}", request?.Request?.UserName);
                return new AuthResult
                {
                    IsAuthenticated = false,
                    Token = null,
                    Message = "Invalid username or password."
                };
            }

            _logger.LogInformation("User authenticated successfully. Generating token and refresh Token for user: {Username}", user.UserName);

            var token = _tokenService.GenerateToken(user);
            var RefreshToken = _tokenService.GenerateRefreshToken();

            await _refreshTokenRepository.AddAsync(new RefreshToken
            {
                Token = RefreshToken,
                Id = user.Id,
                UserId = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            });
            _logger.LogInformation("Tokens generated successfully for user: {Username}", user.UserName);

            return new AuthResult
            {
                IsAuthenticated = true,
                Token = token,
                RefreshToken = RefreshToken,
                Message = "Authentication successful."
            };

        }

    }
}