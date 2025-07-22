using Application.Moduels.ItemGallery.Commands;
using FluentValidation;

namespace Application.Moduels.ItemGallery.Validators
{
    public class DeleteItemGalleryCommandValidator : AbstractValidator<SoftDeleteItemGalleryCommand>
    {


        public DeleteItemGalleryCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }


}
