

using Application.Interfaces.Iservices;
using Domain.Cart;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/CardPayment")]
    [ApiController]
    public class CardPaymentController : ControllerBase
    {
       
        private readonly ICODService _service;

        public CardPaymentController(ICODService service)
        {
            _service = service;
        }

        [HttpPost(Name = "InitiateAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult>  InitiateAsync(Cart cart)
        {
            await _service.InitiateAsync(cart);
            return Ok();
        }

        [HttpPost(Name = "ConfirmAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<bool>> ConfirmAsync(int id)
        {
            await _service.ConfirmAsync(id);
            return Ok();

        }

    }


}

