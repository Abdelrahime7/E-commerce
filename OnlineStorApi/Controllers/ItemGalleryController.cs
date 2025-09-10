using Application.DTOs.ItemGallery;
using Application.Moduels.ItemGallery.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.ItemGallery.Queries.Queries;

namespace OnlineStorApi.Controller
{
    [Route("api/ItemGallerries")]
    [ApiController]
    public class ItemGalleryController : ControllerBase
    {

        private readonly ISender _sender;
        public ItemGalleryController(ISender sender)
        {
            _sender = sender;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet(Name = "GetAllItemsGalleryAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ItemGalleryDto>>> GetAllItemsGalleryAysnc()
        {
            var ItemGallerys = await _sender.Send(new GetAllItemsGalleryQuery());

            if (ItemGallerys.Count != 0)
            {
                return Ok(ItemGallerys);
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{ID}", Name = "GetItemGalleryByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ItemGalleryDto>> GetItemGalleryByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var ItemGallery = await _sender.Send(new GetItemGalleryByIdQuery(id));
            if (ItemGallery != null)
            {
                return Ok(ItemGallery);
            }
            return NotFound();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreatItemGallery")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateItemGalleryAsync([FromBody] ItemGalleryDto request)
        {
            var ItemGalleryID = await _sender.Send(new CreateItemGalleryCommand(request));
            if (ItemGalleryID > 0)
            {
                return CreatedAtRoute($"GetItemGalleryByIDAsync", new { Id = ItemGalleryID }, request);
            }
            return BadRequest("ItemGallery creation failed.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "UpdateItemGallery")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ItemGalleryDto>> UpdateItemGalleryAsync([FromBody] ItemGalleryRequest request)
        {

            if (request.Id > 0)
            {
                var ItemGallery = await _sender.Send(new UpdateItemGalleryCommand(request));
                if (ItemGallery != null)
                {
                    return Ok(ItemGallery);
                }

                return NotFound("ItemGallery not found.");
            }
            return BadRequest(("ItemGallery Updation failed."));


        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeleteItemGallery")]
        public async Task<ActionResult<bool>> DeleteItemGalleryAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteItemGalleryCommand(id)))
            {
                return Ok("ItemGallery Deleted successfully ");
            }

            return BadRequest("ItemGallery not deleted");
        }





    }
}
