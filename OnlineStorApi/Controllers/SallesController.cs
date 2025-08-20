using Application.DTOs.Sale;
using Application.Moduels.Sale.Commands;
using Application.Moduels.Sale.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Sale.Queries.Queries;

namespace OnlineStorApi.Controller
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISender _sender;
        public SalesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllSalesAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetAllSalesAysnc()
        {
            var Sales = await _sender.Send(new GetAllSalesQuery());

            if (Sales.Count != 0)
            {
                return Ok(Sales);
            }

            return NoContent();
        }


        [HttpGet("{ID}", Name = "GetSaleByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<SaleDto>> GetSaleByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Sale = await _sender.Send(new GetSaleByIdQuery(id));
            if (Sale != null)
            {
                return Ok(Sale);
            }
            return NotFound();
        }



        [HttpPost(Name = "CreatSale")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateSaleAsync([FromBody] SaleDto request)
        {
            var SaleID = await _sender.Send(new CreateSaleCommand(request));
            if (SaleID > 0)
            {
                return CreatedAtRoute($"GetSaleByIDAsync", new { Id = SaleID }, request);
            }
            return BadRequest("Sale creation failed.");
        }


        [HttpPut(Name = "UpdateSale")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<ActionResult<SaleDto>> UpdateSaleAsync([FromBody] SaleRequest request)
        {

            if (request.Id > 0)
            {
                var Sale = await _sender.Send(new UpdateSaleCommand(request));
                if (Sale != null)
                {
                    return Ok(Sale);
                }

                return NotFound("Sale not found.");
            }
            return BadRequest(("Sale Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeleteSale")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteSaleAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteSaleCommand(id)))
            {
                return Ok("Sale Deleted successfully ");
            }

            return BadRequest("Sale not deleted");
        }



    }
}
