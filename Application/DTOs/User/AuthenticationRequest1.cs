
namespace Application.DTOs.User
{
    public record AuthenticationRequest
    {
    
        public string? UserName { get; set; }
        public string? Password { get; set; }
       

    }


}