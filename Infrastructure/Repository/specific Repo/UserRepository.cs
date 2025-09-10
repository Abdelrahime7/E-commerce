using Application.DTOs.Authetnication;
using Application.Interface;
using Domain.entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.specific_Repo
{
    public class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
    {
       private readonly DbSet<User> _dbset = context.Set<User>();

        public async Task<User> CheckUserAsync(AuthenticationRequest request)
        {
            var user = await _dbset
           .FirstOrDefaultAsync(u => u.UserName == request.UserName && 
            u.Password == request.Password);

            if (user is null)
                return null;

            return user;
        }

 
    }

}
