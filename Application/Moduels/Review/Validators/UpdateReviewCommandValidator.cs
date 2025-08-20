using Application.Moduels.Review.Commands;
using FluentValidation;

namespace Application.Moduels.Review.Validators
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {


        public UpdateReviewCommandValidator()
        {
            RuleFor(C => C.request.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.request.Descreption).NotEmpty().WithMessage("Descreption is required");
            RuleFor(C => C.request.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.request.CustomerId).NotEmpty().WithMessage("CustomerId is required");
            RuleFor(C => C.request.ItemID).NotEmpty().WithMessage("ItemID is required");
                          
        }



    }

}
