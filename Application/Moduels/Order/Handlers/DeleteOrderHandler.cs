

using Application.Moduels.Order.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Specific.IunitOW;


namespace Application.Moduels.Order.Handlers
{
    public class DeleteOrderHandler(IOrderUnitOfWork unitOfWork) : DeleteHandler<DeleteOrderCommand>
    {

        private readonly IOrderUnitOfWork _unitOfWork = unitOfWork;


        public override async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetByIDAsync(request.ID);
            if (order == null)
                return false;
            var invoices = order.invoices;
            foreach (var invoice in invoices) { 
                await _unitOfWork.InvoiceRepository.DeleteAsync(invoice.Id);
            }

            await _unitOfWork.PurchaseRepository.DeleteAsync(order.PurchaseHistory.Id);
            await _unitOfWork.SaleRepository.DeleteAsync(order.Sale.Id);
            await _unitOfWork.OrderRepository.DeleteAsync(order.Id);

            await _unitOfWork.SaveAsync();
            return true;


        }
    }





}

