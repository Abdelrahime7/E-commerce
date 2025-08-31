using Application.DTOs.Authetnication;
using Application.Interface;
using Application.Interfaces.Iservices;
using Application.Interfaces.Specific;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using static Application.Moduels.Authentication.Commands.Commands;

namespace Application.Moduels.Authentication.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshCommand, AuthResult>
    {
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RefreshTokenHandler> _logger;


        public RefreshTokenHandler(ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository,
             IUserRepository userRepository,
             ILogger<RefreshTokenHandler> logger)
        { 
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository= userRepository;
            _logger= logger;

        }
        public async Task<AuthResult> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {


            var storedToken = await _refreshTokenRepository.GetRefrechTockenAsync(request.Request.RefreshToken);

            if (storedToken == null || storedToken.ExpiryDate < DateTime.UtcNow)
            {
                _logger.LogWarning(" refresh token not found. Token: {Token}", request.Request.RefreshToken);

                return AuthResult.Failure("Invalid Or Epired token");
            } 

            var user = await _userRepository.GetByIDAsync (storedToken.UserId);

            var newAccessToken = _tokenService.GenerateToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            _logger.LogInformation("Generate new Access and refresh tokens Access :{Access},Refresh :{Refresh} ",
                newAccessToken, newRefreshToken);

            storedToken.IsRevoked = true;
            _logger.LogInformation("marke stored token :{token}  as revoked : ", storedToken);


            var random = new Random();
            await _refreshTokenRepository.AddAsync(new RefreshToken
            {
                Id = random.Next(),
                UserId = user.Id,
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),

            });
            _logger.LogInformation("added new refresh token:{token} with expiredate {days} "
                , newRefreshToken, DateTime.UtcNow.AddDays(7));



            return AuthResult.Success(newAccessToken, newRefreshToken);
        }


    }
}

