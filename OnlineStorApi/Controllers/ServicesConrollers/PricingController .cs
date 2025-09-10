

using Application.DTOs.Item;
using Application.Interfaces.Iservices;
using Domain.Cart;
using Domain.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Authorize(Roles = "User,Guest,Customer")]
    [Route("api/Pricing")]
    [ApiController]
    public class PricingController : ControllerBase
    {

        private readonly IPricingService _service;

        public PricingController(IPricingService service)
        {
            _service = service;
        }

        [HttpGet(Name = "CalculatePrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
 
       public ActionResult< decimal> CalculatePrice(Item item, int quantity)
        {
            var Price = _service.CalculatePrice(item, quantity);
            return Ok(Price);
        }

        [HttpPost(Name = "ApplyDiscounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<decimal> ApplyDiscounts(decimal price, int quantity ,Customer customer)
        {
            var Price = _service.ApplyDiscounts(price, quantity, customer);
            return Ok(Price);
        }

        [HttpGet(Name = "CalculateTax")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<decimal> CalculateTax(Item item, decimal netPrice)
        {
            var Tax= _service.CalculateTax(item, netPrice);
            return Ok(Tax);
              
        }

        [HttpGet(Name = "GetPriceDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PriceDetailsDto> GetPriceDetails(Item item, int quantity, Customer customer)
        {
            var PriceDetais= _service.GetPriceDetails(item, quantity, customer);
            return Ok(PriceDetais);
         }

    }
}

