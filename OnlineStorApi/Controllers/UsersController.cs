
using Application.DTOs.User;
using Application.Moduels.User.Commands;
using Application.Moduels.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.User.Queries.Queries;

namespace OnlineStorApi.Controllers
{
    [Route("api/Users")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;
        }



        [HttpGet(Name = "GetAllUsersAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersAysnc()
        {
            var Users = await _sender.Send(new GetAllUsersQuery());

            if (Users.Count != 0)
            {
                return Ok(Users);
            }

            return NoContent();
        }


        [HttpGet("{ID}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<UserDto>> GetUserByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var User = await _sender.Send(new GetUserByIdQuery(id));
            if (User != null)
            {
                return Ok(User);
            }
            return NotFound();
        }



        [HttpPost(Name = "CreatUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateUserAsync([FromBody] UserDto request)
        {
            var UserID = await _sender.Send(new CreateUserCommand(request));
            if (UserID > 0)
            {
                return CreatedAtRoute($"GetUserByIDAsync", new { Id = UserID }, request);
            }
            return BadRequest("User creation failed.");
        }


        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<ActionResult<UserDto>> UpdateUserAsync([FromBody] UserRequest request)
        {

            if (request.Id > 0)
            {
                var User = await _sender.Send(new UpdateUserCommand(request));
                if (User != null)
                {
                    return Ok(User);
                }

                return NotFound("User not found.");
            }
            return BadRequest(("User Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteUserAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteUserCommand(id)))
            {
                return Ok("User Deleted successfully ");
            }

            return BadRequest("User not deleted");
        }

    }


}
