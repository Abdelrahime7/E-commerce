

using Application.DTOs.Authetnication;
using Application.DTOs.User;
using Application.Interfaces.Generic;
using Domain.entities;

namespace Application.Interface
{
    public interface IUserRepository  : IGenericRepository<User> 
    {
        Task<User> CheckUserAsync(AuthenticationRequest request);
    }
}
