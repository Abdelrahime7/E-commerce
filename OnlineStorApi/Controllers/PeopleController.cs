using Application.DTOs.Person;
using Application.Moduels.Person.Commands;
using Application.Moduels.Person.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Person.Queries.Queries;

namespace OnlineStorApi.Controller
{
    [Route("api/People")]
    [ApiController]
    public class PeopleContoller : ControllerBase
    {

        private readonly ISender _sender;
        public PeopleContoller(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet(Name = "GetAllPeopleAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAllPersonsAysnc()
        {
            var Persons = await _sender.Send(new GetAllPeopleQuery());

            if (Persons.Count != 0)
            {
                return Ok(Persons);
            }

            return NoContent();
        }


        [HttpGet("{ID}", Name = "GetPersonByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonDto>> GetPersonByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Person = await _sender.Send(new GetPersonByIdQuery(id));
            if (Person != null)
            {
                return Ok(Person);
            }
            return NotFound();
        }



        [HttpPost(Name = "CreatPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreatePersonAsync([FromBody] PersonDto request)
        {
            var PersonID = await _sender.Send(new CreatePersonCommand(request));
            if (PersonID > 0)
            {
                return CreatedAtRoute($"GetPersonByIDAsync", new { Id = PersonID }, request);
            }
            return BadRequest("Person creation failed.");
        }


        [HttpPut(Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<ActionResult<PersonDto>> UpdatePersonAsync([FromBody] PersonRequest request)
        {

            if (request.Id > 0)
            {
                var Person = await _sender.Send(new UpdatePersonCommand(request));
                if (Person != null)
                {
                    return Ok(Person);
                }

                return NotFound("Person not found.");
            }
            return BadRequest(("Person Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeletePersonAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeletePersonCommand(id)))
            {
                return Ok("Person Deleted successfully ");
            }

            return BadRequest("Person not deleted");
        }





    }
}
