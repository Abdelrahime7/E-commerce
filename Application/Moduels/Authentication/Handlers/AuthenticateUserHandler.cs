
using Application.DTOs.Authetnication;
using Application.Interface;
using Application.Interfaces.Iservices;
using MediatR;
using static Application.Moduels.Authentication.Queries.Queries;


namespace Application.Moduels.Customer.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticateUserHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }




        public async Task<AuthResult> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CheckUserAsync(request.Request);

            if (user is null)
            {
                return new AuthResult
                {
                    IsAuthenticated = false,
                    Token = null,
                    Message = "Invalid username or password."
                };
            }

            var token = _tokenService.GenerateToken(user);

            return new AuthResult
            {
                IsAuthenticated = true,
                Token = token,
                Message = "Authentication successful."
            };
        }

    }
}