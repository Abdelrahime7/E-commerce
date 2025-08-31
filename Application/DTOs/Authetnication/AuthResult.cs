namespace Application.DTOs.Authetnication
{
    public class AuthResult
    {
       
            public bool IsSuccess { get; private set; }
            public string AccessToken { get; private set; }
            public string RefreshToken { get; private set; }
            public string ErrorMessage { get; private set; }

            private AuthResult() { }

            public static AuthResult Success(string accessToken, string refreshToken)
            {
                return new AuthResult
                {
                    IsSuccess = true,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
            }

            public static AuthResult Failure(string errorMessage)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    ErrorMessage = errorMessage
                };
            }
        

    }

}