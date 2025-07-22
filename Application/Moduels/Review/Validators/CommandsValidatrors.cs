using Application.Moduels.Review.Commands;
using FluentValidation;

namespace Application.Moduels.Review.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateReviewCommand>
    {

        
        public CrateCommandValidator()
        {

        RuleFor(C => C.reviewDto.Descreption).NotEmpty().WithMessage("Descreption is required");
            RuleFor(C => C.reviewDto.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.reviewDto.CustomerId).NotEmpty().WithMessage("CustomerId is required");
            RuleFor(C => C.reviewDto.ItemID).NotEmpty().WithMessage("ItemID is required");
             
        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdateReviewCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.Descreption).NotEmpty().WithMessage("Descreption is required");
            RuleFor(C => C.Response.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(C => C.Response.CustomerId).NotEmpty().WithMessage("CustomerId is required");
            RuleFor(C => C.Response.ItemID).NotEmpty().WithMessage("ItemID is required");
                          
        }



    }

    public class DeleteCommandValidator : AbstractValidator<SoftDeleteReviewCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
