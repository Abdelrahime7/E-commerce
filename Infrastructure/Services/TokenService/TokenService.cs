using Application.Interfaces.Generic;
using Application.Interfaces.Iservices;
using Domain.entities;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Shared.Config;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services.TokenService
{
    public class TokenServic : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<TokenServic> _logger;
        private readonly IGetRols _Rols;

        public TokenServic(JwtOptions jwtOptions, ILogger<TokenServic> logger,
            IGetRols Rols)
        {
            _jwtOptions = jwtOptions;
            _logger= logger;
            _Rols= Rols;


        }

        public string GenerateToken(User user)
        {
            _logger.LogInformation("Generating JWT token for user ID: {UserId}, Email: {Email}", user.Id, user.Person.Email);
            var Role = _Rols.Role(user);

            var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Person.Email),
            new Claim(ClaimTypes.Role,Role)
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
        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

    }
}


