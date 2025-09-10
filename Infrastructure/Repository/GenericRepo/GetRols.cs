using Application.Interfaces.Generic;
using Domain.entities;


namespace Infrastructure.Repository.GenericRepo
{
    public class GetRols : IGetRols
    {
        public  string Role(User user)
        {
            return user.Role;
        }
    }
}
