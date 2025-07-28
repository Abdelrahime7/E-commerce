using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.Customer.Commands;
using Application.Moduels.GenericHndlers;
using Domain.entities;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Customer.Handlers
{
  
    public class DeleteCustomerHandler : DeleteHandler<SoftDeleteCustomerCommand>
    {
        private readonly ILogger<DeleteCustomerHandler> _logger;

        private readonly ICustomerUnitOfWork _unitOfWork;

        public DeleteCustomerHandler(ICustomerUnitOfWork unitOfWork
            , ILogger<DeleteCustomerHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public override async Task<bool> Handle(SoftDeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var customer = await _unitOfWork.CustomerRepository.GetByIDAsync(request.ID);
                _logger.LogInformation("Get Customer with id : {ID}", request.ID);

                if (customer != null)
                {
                    _logger.LogInformation("customer found. Proceeding to soft delete customer ID {id}", customer.Id);
                    await _unitOfWork.PersonRepository.SoftDeleteAsync(customer.PersonID);
                    await _unitOfWork.CustomerRepository.SoftDeleteAsync(customer.Id);
                    var result= await _unitOfWork.SaveAsync() > 0;
                    _logger.LogInformation("Soft delete completed for customer ID {Id}", customer.Id);
                    return result;

                }
            }
            catch (Exception ex) {
                _logger.LogError( ex,"Erorr Customer Not Deleted"); 
                throw new Exception(ex.Message);
                
            }
                   return false;
        }
    }






}

