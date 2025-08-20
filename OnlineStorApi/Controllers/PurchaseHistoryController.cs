using Application.DTOs.Purchase;
using Application.Moduels.Purchase.Commands;
using Application.Moduels.Purchase.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Purchase.Queries.Queries;

namespace OnlineStorApi.Controller
{
    [Route("api/PurchasesHistory")]
    [ApiController]
    public class PurchaseHistoryHistoryController : ControllerBase
    {
        private readonly ISender _sender;
        public PurchaseHistoryHistoryController(ISender sender)
        {
            _sender = sender;
        }



        [HttpGet(Name = "GetAllPurchasesAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<PurchasHistoryDto>>> GetAllPurchasesAysnc()
        {
            var Purchases = await _sender.Send(new GetAllPurchasesQuery());

            if (Purchases.Count != 0)
            {
                return Ok(Purchases);
            }

            return NoContent();
        }


        [HttpGet("{ID}", Name = "GetPurchaseByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PurchasHistoryDto>> GetPurchaseByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Purchase = await _sender.Send(new GetPurchaseByIdQuery(id));
            if (Purchase != null)
            {
                return Ok(Purchase);
            }
            return NotFound();
        }



        [HttpPost(Name = "CreatPurchase")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreatePurchaseAsync([FromBody] PurchasHistoryDto request)
        {
            var PurchaseID = await _sender.Send(new CreatePurchaseCommand(request));
            if (PurchaseID > 0)
            {
                return CreatedAtRoute($"GetPurchaseByIDAsync", new { Id = PurchaseID }, request);
            }
            return BadRequest("Purchase creation failed.");
        }


        [HttpPut(Name = "UpdatePurchase")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<ActionResult<PurchasHistoryDto>> UpdatePurchaseAsync([FromBody] PurchasHistoryRequest request)
        {

            if (request.Id > 0)
            {
                var Purchase = await _sender.Send(new UpdatePurchaseCommand(request));
                if (Purchase != null)
                {
                    return Ok(Purchase);
                }

                return NotFound("Purchase not found.");
            }
            return BadRequest(("Purchase Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeletePurchase")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeletePurchaseAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeletePurchaseCommand(id)))
            {
                return Ok("Purchase Deleted successfully ");
            }

            return BadRequest("Purchase not deleted");
        }





    }
}
