using Application.DTOs.Person;
using MediatR;

namespace Application.Moduels.Person.Queries
{
    public class Queries
    {
        public record GetPersonByIdQuery(int Id) : IRequest<PersonDto>;
        public record GetAllPeopleQuery : IRequest<IReadOnlyCollection<PersonDto>>;

    }

}
