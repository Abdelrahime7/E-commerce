using Application.DTOs.Authetnication;
using Application.Interface;
using Application.Interfaces.Iservices;
using Application.Interfaces.Specific;
using Domain.Entities;
using MediatR;
using static Application.Moduels.Authentication.Commands.Commands;

namespace Application.Moduels.Authentication.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshCommand, AuthResult>
    {
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;



        public RefreshTokenHandler(ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository,
             IUserRepository userRepository)
        { 
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository= userRepository;

        }
        public async Task<AuthResult> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {


            var storedToken = await _refreshTokenRepository.GetRefrechTockenAsync(request.Request.RefreshToken);
          
            if (storedToken == null || storedToken.ExpiryDate < DateTime.UtcNow)
                return AuthResult.Failure("Invalid Or Epired token"); 
               

            var user = await _userRepository.GetByIDAsync (storedToken.UserId);

            var newAccessToken = _tokenService.GenerateToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            storedToken.IsRevoked = true;

            var random = new Random();
            await _refreshTokenRepository.AddAsync(new RefreshToken
            {
                Id = random.Next(),
                UserId = user.Id,
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),

            });

           

            return AuthResult.Success(newAccessToken, newRefreshToken);
        }


    }
}

