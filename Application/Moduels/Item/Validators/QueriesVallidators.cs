using FluentValidation;
using static Application.Moduels.Item.Queries.Queries;

namespace Application.Moduels.Item.Validators
{
    public class GetByIdValidator : AbstractValidator<GetItemByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
