using Application.DTOs.Item;
using Application.Moduels.Item.Commands;
using Application.Moduels.Item.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Item.Queries.Queries;

namespace OnlineStorApi.Controller
{
    [Route("api/Items")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly ISender _sender;
        public ItemController(ISender sender)
        {
            _sender = sender;
        }



        [HttpGet(Name = "GetAllItemsAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItemsAysnc()
        {
            var Items = await _sender.Send(new GetAllItemsQuery());

            if (Items.Count != 0)
            {
                return Ok(Items);
            }

            return NoContent();
        }


        [HttpGet("{ID}", Name = "GetItemByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ItemDto>> GetItemByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Item = await _sender.Send(new GetItemByIdQuery(id));
            if (Item != null)
            {
                return Ok(Item);
            }
            return NotFound();
        }



        [HttpPost(Name = "CreatItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateItemAsync([FromBody] ItemDto request)
        {
            var ItemID = await _sender.Send(new CreateItemCommand(request));
            if (ItemID > 0)
            {
                return CreatedAtRoute($"GetItemByIDAsync", new { Id = ItemID }, request);
            }
            return BadRequest("Item creation failed.");
        }


        [HttpPut(Name = "UpdateItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ItemDto>> UpdateItemAsync([FromBody] ItemRequest request)
        {

            if (request.Id > 0)
            {
                var Item = await _sender.Send(new UpdateItemCommand(request));
                if (Item != null)
                {
                    return Ok(Item);
                }

                return NotFound("Item not found.");
            }
            return BadRequest(("Item Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeleteItem")]
        public async Task<ActionResult<bool>> DeleteItemAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteItemCommnd(id)))
            {
                return Ok("Item Deleted successfully ");
            }

            return BadRequest("Item not deleted");
        }




    }
}
