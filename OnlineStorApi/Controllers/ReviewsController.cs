using Application.DTOs.Review;
using Application.Moduels.Review.Commands;
using Application.Moduels.Review.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Moduels.Review.Queries.Queries;


namespace OnlineStorApi.Controller
{
    [Route("api/Reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ISender _sender;
        public ReviewsController(ISender sender)
        {
            _sender = sender;
        }



        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetAllReviewsAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviewsAysnc()
        {
            var Reviews = await _sender.Send(new GetAllReviewsQuery());

            if (Reviews.Count != 0)
            {
                return Ok(Reviews);
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{ID}", Name = "GetReviewByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ReviewDto>> GetReviewByIDAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid id = {id}");
            }
            var Review = await _sender.Send(new GetReviewByIdQuery(id));
            if (Review != null)
            {
                return Ok(Review);
            }
            return NotFound();
        }


        [Authorize(Roles = "User,Geust,Customer")]
        [HttpPost(Name = "CreatReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateReviewAsync([FromBody] ReviewDto request)
        {
            var ReviewID = await _sender.Send(new CreateReviewCommand(request));
            if (ReviewID > 0)
            {
                return CreatedAtRoute($"GetReviewByIDAsync", new { Id = ReviewID }, request);
            }
            return BadRequest("Review creation failed.");
        }

        [Authorize(Roles = "User,Geust,Customer")]

        [HttpPut(Name = "UpdateReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ReviewDto>> UpdateReviewAsync([FromBody] ReviewRequest request)
        {

            if (request.Id > 0)
            {
                var Review = await _sender.Send(new UpdateReviewCommand(request));
                if (Review != null)
                {
                    return Ok(Review);
                }

                return NotFound("Review not found.");
            }
            return BadRequest(("Review Updation failed."));


        }

        [Authorize(Roles = "User,Geust,Customer")]

        [HttpDelete("{id}", Name = "DeleteReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteReviewAsync(int id)
        {
            if (id < 1)
            {
                return NoContent();
            }
            if (await _sender.Send(new DeleteReviewCommand(id)))
            {
                return Ok("Review Deleted successfully ");
            }

            return BadRequest("Review not deleted");
        }


    }
}
