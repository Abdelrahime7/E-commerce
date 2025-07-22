using Application.Moduels.Review.Commands;
using FluentValidation;

namespace Application.Moduels.Review.Validators
{

    public class DeleteReviewCommandValidator : AbstractValidator<SoftDeleteReviewCommand>
    {


        public DeleteReviewCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
