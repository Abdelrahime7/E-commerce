using Application.Moduels.Review.Commands;
using FluentValidation;

namespace Application.Moduels.Review.Validators
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {


        public UpdateReviewCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.Descreption).NotEmpty().WithMessage("Descreption is required");
            RuleFor(C => C.Response.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.Response.CustomerId).NotEmpty().WithMessage("CustomerId is required");
            RuleFor(C => C.Response.ItemID).NotEmpty().WithMessage("ItemID is required");
                          
        }



    }

}
