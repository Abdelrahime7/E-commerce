using Application.DTOs.Invoice;
using Application.Moduels.Invoice.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Invoice.Queries.Queries;


namespace OnlineStorApi.Controller
{
    [Authorize(Roles = "Admin")]
    [Route("api/Invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ISender _sender;
        public InvoiceController(ISender sender)
        {
            _sender = sender;
        }


        [Authorize(Roles = "Admin")]

        [HttpGet(Name = "GetAllInvoicesAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAllInvoicesAysnc()
        {
            var Invoices = await _sender.Send(new GetAllInvoicesQuery());

            if (Invoices.Count != 0)
            {
                return Ok(Invoices);
            }

            return NoContent();
        }


        [HttpGet("{ID}", Name = "GetInvoiceByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<InvoiceDto>> GetInvoiceByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Invoice = await _sender.Send(new GetInvoiceByIdQuery(id));
            if (Invoice != null)
            {
                return Ok(Invoice);
            }
            return NotFound();
        }



        [HttpPost(Name = "CreatInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateInvoiceAsync([FromBody] InvoiceDto request)
        {
           var InvoiceID = await _sender.Send(new CreateInvoiceCommand(request));
            if (InvoiceID > 0)
            {
                return CreatedAtRoute($"GetInvoiceByIDAsync", new { Id = InvoiceID }, request);
            }
            return BadRequest("Invoice creation failed.");
        }


        [HttpPut(Name = "UpdateInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InvoiceDto>> UpdateInvoiceAsync([FromBody] InvoiceRequest request)
        {

            if (request.Id> 0)
            {
                var Invoice = await _sender.Send(new UpdateInvoiceCommand(request));
                if (Invoice != null)
                {
                    return Ok(Invoice);
                }

                return NotFound("Invoice not found.");
            }
            return BadRequest(("Invoice Updation failed."));


        }


        [HttpDelete("{id}", Name = "DeleteInvoice")]
        public async Task<ActionResult<bool>> DeleteInvoiceAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteInvoiceCommand(id)))
            {
                return Ok("Invoice Deleted successfully ");
            }

            return BadRequest("Invoice not deleted");
        }





    }
}
