using Application.Interfaces.Generic;
using Domain.Entities;


namespace Application.Interfaces.Specific
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken> GetRefrechTockenAsync(string RefreshToken);
        Task ReplaceTockenAsync(string OldToken, string NewToken);
        
    }
}
