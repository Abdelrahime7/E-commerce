using Application.Moduels.ItemGallery.Commands;
using FluentValidation;

namespace Application.Moduels.ItemGallery.Validators
{
    public class CrateItemGalleryCommandValidator : AbstractValidator<CreateItemGalleryCommand>
    {

        
        public CrateItemGalleryCommandValidator()
        {
            RuleFor(C => C.itemGalleryDto.ItemID).NotEmpty().WithMessage("Item ID is required");
            RuleFor(C => C.itemGalleryDto.ImageLink).NotEmpty().WithMessage("Images Linkis required");
           
        }



    }


}
