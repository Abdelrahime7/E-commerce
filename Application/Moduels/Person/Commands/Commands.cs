using Application.DTOs.Person;
using MediatR;


namespace Application.Moduels.Person.Commands
{
    public record CreatePersonCommand(PersonDto personDto) : IRequest<int>;
    public record UpdatePersonCommand(PersonRequest request) : IRequest<PersonDto>;
    public record DeletePersonCommand(int ID) : IRequest<bool>;
    public record SoftDeletePersonCommand(int ID) : IRequest<bool>;


}
