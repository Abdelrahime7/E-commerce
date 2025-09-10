

using Application.Interfaces.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Authorize(Roles = "User,Guest,Customer")]
    [Route("api/COD")]
    [ApiController]
    public class CardPaymentController : ControllerBase
    {

        private readonly IPaymentService _service;

        public CardPaymentController(IPaymentService service)
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

