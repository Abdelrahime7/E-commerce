using Application.DTOs.Review;
using MediatR;


namespace Application.Moduels.Review.Commands
{
    public record CreateReviewCommand(ReviewDto reviewDto) : IRequest<int>;
    public record UpdateReviewCommand(ReviewResponse Response) : IRequest<ReviewDto>;
    public record DeleteReviewCommand(int ID) : IRequest<bool>;
    public record SoftDeleteReviewCommand(int ID) : IRequest<bool>;



}
