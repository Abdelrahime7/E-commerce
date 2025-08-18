
using Application.DTOs.Inventory;
using Application.DTOs.Inventory;
using Application.DTOs.Inventory;
using Application.Moduels.Inventory.Commands;
using Application.Moduels.Inventory.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Inventory.Queries.Queries;
using static Application.Moduels.Inventory.Queries.Queries;


namespace OnlineStorApi.Controller
{
    [Route("api/Inventories")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly ISender _sender;
        public InventoriesController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddInventory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreatInventoryAsync(CreateInventoryCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetInventoryByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }
        [HttpPost("{ID}",Name = "GetInventoryByID")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InventoryDto>> GetInventoryByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Inventory = await _sender.Send(new GetInventoryByIdQuery(id));
            if (Inventory != null)
            {
                return Ok(Inventory);
            }
            return NotFound();
        }

        [HttpGet(Name = "GetAllInventoriesAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetAllInventoriesAysnc()
        {
            var Inventories = await _sender.Send(new GetAllInventoriesQuery());

            if (Inventories.Count != 0)
            {
                return Ok(Inventories);
            }

            return NoContent();
        }

        [HttpPut(Name = "UpdateInventory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InventoryDto>> Put([FromBody] InventoryRequest Inventory)
        {

            if (Inventory.Id > 0)
            {
                var inventory = await _sender.Send(new UpdateInventoryCommand(Inventory));
                if (inventory != null)
                {
                    return Ok(inventory);
                }

                return NotFound("Inventory not found.");
            }
            return BadRequest(("Inventory Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeleteInventory")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteInventoryCommand(id)))
            {
                return Ok("Inventory Deleted successfully ");
            }

            return BadRequest("Inventory not deleted");
        }
    }


}

