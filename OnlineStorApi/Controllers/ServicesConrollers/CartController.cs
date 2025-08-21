

using Application.Interfaces.Iservices;
using Domain.Cart;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
       
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

      
        [HttpPost(Name = "AddItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult  AddItem (ItemDetaills item)
        
        {
             
           _cartService.AddItem(item);
            return Ok(item);
        }


        [HttpDelete(Name = "RemoveItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult RemoveItem(Guid ID)
        {
            if (ID.Equals(default))
            {
                return NotFound($"ID = {ID} is nt valid");
            }
            _cartService.RemoveItem(ID);
            return Ok("");
        }


        [HttpPatch(Name = "UpdateQuantity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateQuantity(Guid itemDetaillsID, int quantity)
        {
            if (itemDetaillsID.Equals(default))
            {
                return NotFound($" items details with id  = {itemDetaillsID} is not found");
            }
            _cartService.UpdateQuantity(itemDetaillsID, quantity);
            return Ok("Quantity updated");
        }


        [HttpGet(Name = "GetTotalAmount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<decimal> GetTotalAmount()

        {
            var TotalAmount= _cartService.GetTotalAmount();
            if (TotalAmount.Equals(default))
            {
                return NoContent();
            }
            return Ok(TotalAmount);
        }



        [HttpGet(Name = "GetItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<ItemDetaills> GetItems() {
            var Items = _cartService.GetItems();
            if (Items.Count>0)
            {
                return Ok(Items);
            }
            return NoContent();
        }


    }


}

