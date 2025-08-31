

using Application.Interfaces.Specific;
using Domain.Entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.specific_Repo
{
    public class RefreshTokenRepository (AppDbContext context):GenericRepository<RefreshToken>(context), IRefreshTokenRepository

    {

        private readonly DbSet<RefreshToken> _dbSet=context.Set< RefreshToken>();

        public async Task<RefreshToken?> GetRefrechTockenAsync(string refreshToken) =>
            await _dbSet.FirstOrDefaultAsync(r => r.Token == refreshToken&& !r.IsRevoked);

        public async Task ReplaceTockenAsync(string oldToken ,string newToken)

        {
            var token = await _dbSet.FirstOrDefaultAsync(t => t.Token == oldToken);
            if (token != null)
            {
                token.Token = newToken;
                token.CreatedDate = DateTime.UtcNow;
                token.ExpiryDate = DateTime.UtcNow.AddDays(7);
                token.IsRevoked = false;
                await  context.SaveChangesAsync();


            }





        }
    }
}
