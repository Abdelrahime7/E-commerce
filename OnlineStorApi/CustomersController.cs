using Application.DTOs.Customer;
using Application.Moduels.Customer.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Customer.Queries.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStorApi
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Mediator _mediator;

        public CustomersController(Mediator mediator)
        {
            _mediator = mediator;
        }

      

       
            [HttpGet(Name = "GetAllCustomersAysnc")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public async  Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomersAysnc()
            {
                var customers = await _mediator.Send(new GetAllCustomersQuery());

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
            if (id<1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Customer =await _mediator.Send(new GetCustomerByIdQuery(id));
            if (Customer != null)
            {
                return Ok(Customer);
            }
            return NotFound();
        }

      
        
        [HttpPost(Name = "CreatCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<int>> CreateCustomer([FromBody]CustomerRequest customer)
        {
            await _mediator.Send(new CreateCustomerCommand(customer));
            if (customer.ID > 0)
            {
                return CreatedAtRoute($"GetCusomerByIDAsync", new { Id = customer.ID }, customer);
            }
            return BadRequest("Customer creation failed.");
        }


        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerDto>> Put( [FromBody]CustomerRequest customer )
        {

            if (customer.ID > 0)
            {
               var Customer= await _mediator.Send(new UpdateCustomerCommand(customer));
                if (Customer != null) {
                    return Ok(Customer); }

                return NotFound("Customer not found.");
            }
            return BadRequest(("Customer Updation failed."));
           

        }

   
        [HttpDelete("{id}",Name ="DeleteCustomer")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id<1)
            {
                return NoContent();
            }
            if (await _mediator.Send(new DeleteCustomerCommand(id)))
            {
                return Ok("Customer Deleted successfully ");
            }

            return BadRequest("Customer not deleted");
        }
    }
}
