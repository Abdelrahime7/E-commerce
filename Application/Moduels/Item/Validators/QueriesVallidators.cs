using FluentValidation;
using static Application.Moduels.Item.Queries.Queries;

namespace Application.Moduels.Item.Validators
{
    public class GetItemByIdValidator : AbstractValidator<GetItemByIdQuery>
    {
        public GetItemByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
