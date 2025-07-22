using Application.Moduels.ItemGallery.Commands;
using FluentValidation;

namespace Application.Moduels.ItemGallery.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateItemGalleryCommand>
    {

        
        public CrateCommandValidator()
        {
            RuleFor(C => C.itemGalleryDto.ItemID).NotEmpty().WithMessage("Item ID is required");
            RuleFor(C => C.itemGalleryDto.ImageLink).NotEmpty().WithMessage("Images Linkis required");
           
        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdateItemGalleryCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.ItemID).NotEmpty().WithMessage("Item ID is required");
            RuleFor(C => C.Response.ImageLink).NotEmpty().WithMessage("Images Linkis required");


        }



    }
    public class DeleteCommandValidator : AbstractValidator<SoftDeleteItemGalleryCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
