using Application.DTOs.Customer;
using MediatR;


namespace Application.Moduels.Customer.Commands
{
  
 
   public record CreateCustomerCommand(CustomerDto customerDto) : IRequest<int>;
   public record UpdateCustomerCommand(CustomerResponse Response) : IRequest<CustomerDto>;
    
    public record DeleteCustomerCommand(int ID) : IRequest<bool>;
 



}
