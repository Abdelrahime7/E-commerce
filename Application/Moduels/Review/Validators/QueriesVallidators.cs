using FluentValidation;
using static Application.Moduels.Review.Queries.Queries;

namespace Application.Moduels.Review.Validators
{
    public class GetReviewByIdValidator : AbstractValidator<GetReviewByIdQuery>
    {
        public GetReviewByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
