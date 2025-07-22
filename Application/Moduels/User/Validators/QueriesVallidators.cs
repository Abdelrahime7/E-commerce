using FluentValidation;
using static Application.Moduels.User.Queries.Queries;

namespace Application.Moduels.User.Validators
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
