using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrdersController(IOrderService service)
        {
            _service = service;
        }



        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetAllOrdersAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrdersAysnc()
        {
            var Orders = await _service.GetAllOrdersAsync();

            if (Orders.Any())
            {
                return Ok(Orders);
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{ID}", Name = "GetOrderByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<OrderDto>> GetOrderByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Order = await _service.GetOrderByIDAsync(id);
            if (Order != null)
            {
                return Ok(Order);
            }
            return NotFound();
        }


        [Authorize(Roles = "Admin,User,Guest")]
        [HttpPost(Name = "CreatOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateOrderAsync([FromBody] OrderDto request)
        {
           var OrderID=  await _service.PlaceOrderAsync(request);
            if (OrderID > 0) 
            {
                return CreatedAtRoute($"GetOrderByIDAsync", new { Id = OrderID }, request);
            }
            return BadRequest("Order creation failed.");
        }

        [Authorize(Roles = "Admin,User,Guest")]
        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> UpdateOrderAsync([FromBody] OrderRequest request)
        {

            if (request.Id > 0)
            {
                var Order = await _service.UpdateOrderAsync(request);
                if (Order != null)
                {
                    return Ok(Order);
                }

                return NotFound("Order not found.");
            }
            return BadRequest(("Order Updation failed."));


        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<ActionResult<bool>> DeleteOrderAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _service.SoftDeleteOrderAsync(id)) 
            {      
                return Ok("Order Deleted successfully ");
            }

            return BadRequest("Order not deleted");
        }



    }
}
