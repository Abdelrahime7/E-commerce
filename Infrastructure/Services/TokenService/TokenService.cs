using Application.Interfaces.Iservices;
using Domain.entities;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Shared.Config;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.TokenService
{
    public class TokenServic : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<TokenServic> _logger;

        public TokenServic(JwtOptions jwtOptions, ILogger<TokenServic> logger)
        {
            _jwtOptions = jwtOptions;
            _logger= logger;
        }

        public string GenerateToken(User user)
        {
            _logger.LogInformation("Generating JWT token for user ID: {UserId}, Email: {Email}", user.Id, user.Person.Email);

            var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Person.Email),
          
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiryMinutes),
                    signingCredentials: creds
                );
            _logger.LogInformation("JWT token generated successfully for user ID: {UserId}. Token expires at: {Expiry}", user.Id, token.ValidTo);
            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }


    }
}

