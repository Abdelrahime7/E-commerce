using FluentValidation;
using static Application.Moduels.ItemGallery.Queries.Queries;

namespace Application.Moduels.ItemGallery.Validators
{
    public class GetItemGalleryByIdValidator : AbstractValidator<GetItemGalleryByIdQuery>
    {
        public GetItemGalleryByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
