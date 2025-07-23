using Application.Moduels.Customer.Commands;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.GenericHndlers;

namespace Application.Moduels.Customer.Handlers
{
  
    public class DeleteCustomerHandler : DeleteHandler<SoftDeleteCustomerCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public DeleteCustomerHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<bool> Handle(SoftDeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var customer = await _unitOfWork.CustomerRepository.GetByIDAsync(request.ID);
                if (customer != null)
                {
                    await _unitOfWork.PersonRepository.SoftDeleteAsync(customer.PersonID);
                    await _unitOfWork.CustomerRepository.SoftDeleteAsync(customer.Id);
                    return await _unitOfWork.SaveAsync() > 0;

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
                   return false;
        }
    }






}

