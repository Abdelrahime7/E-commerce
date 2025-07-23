

using Application.Moduels.Order.Commands;
using Application.Moduels.GenericHndlers;

using Application.Interfaces.Specific.IunitOW;


namespace Application.Moduels.Order.Handlers
{
    public class DeleteOrderHandler(IOrderUnitOfWork unitOfWork) : DeleteHandler<SoftDeleteOrderCommand>
    {

        private readonly IOrderUnitOfWork _unitOfWork = unitOfWork;


        public override async Task<bool> Handle(SoftDeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIDAsync(request.ID);
                if (order == null)
                    return false;
                var invoices = order.invoices;
                foreach (var invoice in invoices)
                {
                    await _unitOfWork.InvoiceRepository.SoftDeleteAsync(invoice.Id);
                }

                await _unitOfWork.PurchaseRepository.SoftDeleteAsync(order.PurchaseHistory.Id);
                await _unitOfWork.SaleRepository.SoftDeleteAsync(order.Sale.Id);
                await _unitOfWork.OrderRepository.SoftDeleteAsync(order.Id);

                return await _unitOfWork.SaveAsync() > 0;
            }
            catch (Exception ex) {throw new Exception(ex.Message); }

        }
    }





}

