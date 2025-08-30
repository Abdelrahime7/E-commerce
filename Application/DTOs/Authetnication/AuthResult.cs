namespace Application.DTOs.Authetnication
{
    public record AuthResult
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string RefreshToken {  get; set; }
        public string Message { get; set; }
    }

}