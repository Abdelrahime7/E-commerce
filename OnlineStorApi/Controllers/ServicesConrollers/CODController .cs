

using Application.Interfaces.Iservices;
using Domain.Cart;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/COD")]
    [ApiController]
    public class CODController : ControllerBase
    {

        private readonly IPaymentService _service;

        public CODController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost(Name = "CreateCheckoutSessionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
      public async Task<ActionResult<string>> CreateCheckoutSessionAsync(decimal amount, string currency)
        {
          
             await _service.CreateCheckoutSessionAsync(amount, currency);
            return Ok();
        }


    }
}

