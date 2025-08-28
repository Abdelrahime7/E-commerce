
using Application.DTOs.Authetnication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Authentication.Queries.Queries;
namespace OnlineStorApi.Controllers
{
    [Route("api/Authentications")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthenticationsController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost(Name = "authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            var result = await _sender.Send(new AuthenticateUserQuery(request));

            if (!result.IsAuthenticated)
                return Unauthorized(result);

            return Ok(result);
        }




    }
}