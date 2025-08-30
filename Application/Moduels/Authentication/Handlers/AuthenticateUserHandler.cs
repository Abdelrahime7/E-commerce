
using Application.DTOs.Authetnication;
using Application.Interface;
using Application.Interfaces.Iservices;
using MediatR;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Authentication.Queries.Queries;


namespace Application.Moduels.Customer.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthenticateUserHandler> _logger;

        public AuthenticateUserHandler(IUserRepository userRepository,
            ITokenService tokenService,
            ILogger<AuthenticateUserHandler> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
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

            _logger.LogInformation("User authenticated successfully. Generating token for user: {Username}", user.UserName);

            var token = _tokenService.GenerateToken(user);

            _logger.LogInformation("Token generated successfully for user: {Username}", user.UserName);

            return new AuthResult
            {
                IsAuthenticated = true,
                Token = token,
                Message = "Authentication successful."
            };

        }

    }
}