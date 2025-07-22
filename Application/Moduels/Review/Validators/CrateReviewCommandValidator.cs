using Application.Moduels.Review.Commands;
using FluentValidation;

namespace Application.Moduels.Review.Validators
{
    public class CrateReviewCommandValidator:AbstractValidator<CreateReviewCommand>
    {

        
        public CrateReviewCommandValidator()
        {

        RuleFor(C => C.reviewDto.Descreption).NotEmpty().WithMessage("Descreption is required");
            RuleFor(C => C.reviewDto.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.reviewDto.CustomerId).NotEmpty().WithMessage("CustomerId is required");
            RuleFor(C => C.reviewDto.ItemID).NotEmpty().WithMessage("ItemID is required");
             
        }



    }

}
