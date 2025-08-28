using Domain.entities;


namespace Application.Interfaces.Iservices
{
    public interface ITokenService
    {
        string GenerateToken(User user);

    }
}
