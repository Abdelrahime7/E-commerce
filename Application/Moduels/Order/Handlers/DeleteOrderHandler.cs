

using Application.Moduels.Order.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Specific.IunitOW;
using Microsoft.Extensions.Logging;
using Domain.entities;
using Microsoft.AspNetCore.Http;


namespace Application.Moduels.Order.Handlers
{
    public class DeleteOrderHandler(IOrderUnitOfWork unitOfWork,
        ILogger<DeleteOrderHandler>logger) : DeleteHandler<SoftDeleteOrderCommand>
    {
        private readonly ILogger<DeleteOrderHandler> _logger=logger;
        private readonly IOrderUnitOfWork _unitOfWork = unitOfWork;


        public override async Task<bool> Handle(SoftDeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to soft delete Order with ID {Id}", request.ID);

                var order = await _unitOfWork.OrderRepository.GetByIDAsync(request.ID);
                _logger.LogInformation("Get Order with id = {ID}", request.ID);
                if (order == null)
                {
                    _logger.LogWarning("Order with id = {ID} not found", request.ID);
                    return false;
                }

                var invoices = order.invoices;
                _logger.LogInformation("get all invoices within this order");

                foreach (var invoice in invoices)
                {
                    await _unitOfWork.InvoiceRepository.SoftDeleteAsync(invoice.Id);
                }
              

                await _unitOfWork.PurchaseRepository.SoftDeleteAsync(order.PurchaseHistory.Id);
                _logger.LogInformation("SoftDelete  purchase  within this order");

                await _unitOfWork.SaleRepository.SoftDeleteAsync(order.Sale.Id);
                _logger.LogInformation("SoftDelete  Sale  within this order");


                await _unitOfWork.OrderRepository.SoftDeleteAsync(order.Id);
                _logger.LogInformation("SoftDelete  ORder with {orderID}",order.Id);


                 var results= await _unitOfWork.SaveAsync() > 0;
                _logger.LogInformation("Soft delete completed for order ID {Id}", order.Id);

                return results;

            }
            catch (Exception ex) {
                _logger.LogError(ex, "{Orderid}  not deleted", request.ID);
                throw new Exception(ex.Message); }

        }
    }





}

