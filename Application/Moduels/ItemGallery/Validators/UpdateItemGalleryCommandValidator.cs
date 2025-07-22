using Application.Moduels.ItemGallery.Commands;
using FluentValidation;

namespace Application.Moduels.ItemGallery.Validators
{
    public class UpdateItemGalleryCommandValidator : AbstractValidator<UpdateItemGalleryCommand>
    {


        public UpdateItemGalleryCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.ItemID).NotEmpty().WithMessage("Item ID is required");
            RuleFor(C => C.Response.ImageLink).NotEmpty().WithMessage("Images Linkis required");


        }



    }


}
