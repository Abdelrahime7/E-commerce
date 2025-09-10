using Application.DTOs.Customer;
using Application.Moduels.Customer.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Customer.Queries.Queries;
namespace OnlineStorApi.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomersController(ISender sender)
        {
            _sender = sender;
        }



        
        [HttpGet(Name = "GetAllCustomersAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomersAysnc()
        {
            var customers = await _sender.Send(new GetAllCustomersQuery());

            if (customers.Count != 0)
            {
                return Ok(customers);
            }

            return NoContent();
        }


        [HttpGet("{ID}", Name = "GetCusomerByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CustomerDto>> GetCusomerByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Customer = await _sender.Send(new GetCustomerByIdQuery(id));
            if (Customer != null)
            {
                return Ok(Customer);
            }
            return NotFound();
        }



        [HttpPost(Name = "CreatCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] CustomerRequest customer)
        {
            await _sender.Send(new CreateCustomerCommand(customer));
            if (customer.ID > 0)
            {
                return CreatedAtRoute($"GetCusomerByIDAsync", new { Id = customer.ID }, customer);
            }
            return BadRequest("Customer creation failed.");
        }


        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerDto>> Put([FromBody] CustomerRequest customer)
        {

            if (customer.ID > 0)
            {
                var Customer = await _sender.Send(new UpdateCustomerCommand(customer));
                if (Customer != null)
                {
                    return Ok(Customer);
                }

                return NotFound("Customer not found.");
            }
            return BadRequest(("Customer Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeleteCustomer")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteCustomerCommand(id)))
            {
                return Ok("Customer Deleted successfully ");
            }

            return BadRequest("Customer not deleted");
        }
    }
}
