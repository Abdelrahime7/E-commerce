using Application.Moduels.Customer.Commands;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.GenericHndlers;

namespace Application.Moduels.Customer.Handlers
{
  
    public class DeleteCustomerHandler : DeleteHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public DeleteCustomerHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIDAsync(request.ID);
                 if (customer != null)
                   {
                        await _unitOfWork.PersonRepository.DeleteAsync(customer.PersonID);
                        await _unitOfWork.CustomerRepository.DeleteAsync(customer.Id);
                        return true;
                    }

                   return false;
        }
    }






}

