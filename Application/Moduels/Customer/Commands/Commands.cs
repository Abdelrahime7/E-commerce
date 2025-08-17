using Application.DTOs.Customer;
using MediatR;


namespace Application.Moduels.Customer.Commands
{
  
 
   public record CreateCustomerCommand(CustomerRequest customer) : IRequest<int>;
   public record UpdateCustomerCommand(CustomerRequest Request) : IRequest<CustomerDto>;
    
    public record DeleteCustomerCommand(int ID) : IRequest<bool>;

    public record SoftDeleteCustomerCommand(int ID) : IRequest<bool>;





}
