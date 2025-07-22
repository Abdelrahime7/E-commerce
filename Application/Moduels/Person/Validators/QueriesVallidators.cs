using FluentValidation;
using static Application.Moduels.Person.Queries.Queries;

namespace Application.Moduels.Person.Validators
{
    public class GetPersonByIdValidator : AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdValidator()
        {
            RuleFor(C => C.Id).NotEqual(0).NotEmpty().WithMessage("ID is required");
        }
    }
}
