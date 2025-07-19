using Application.DTOs.Review;
using MediatR;


namespace Application.Moduels.Review.Queries
{
    public class Queries
    {
        public record GetReviewByIdQuery(int Id) : IRequest<ReviewDto>;
    }
}
