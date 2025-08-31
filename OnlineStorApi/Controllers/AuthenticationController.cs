
using Application.DTOs.Authetnication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Authentication.Commands.Commands;
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

            if (!result.IsSuccess)
                return Unauthorized(result);

            return Ok(result);
        }


        [HttpPost(Name = "LogOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogOut([FromBody] LogOutRequest request)
        {
            var result = await _sender.Send(new LogoutCommand(request));

            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

        [HttpPost(Name = "Refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            var result = await _sender.Send(new RefreshCommand(request));

            if (!result.IsSuccess)
                return Unauthorized(result);

            return Ok(result);
        }




    }
}