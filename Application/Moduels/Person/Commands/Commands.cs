using Application.DTOs.Customer;
using Application.DTOs.Person;
using MediatR;


namespace Application.Moduels.Person.Commands
{
    public record CreatePersonCommand(PersonDto personDto) : IRequest<int>;
    public record UpdatePersonCommand(PersonResponse Response) : IRequest<PersonDto>;
    public record DeletePersonCommand(int ID) : IRequest<bool>;

}
