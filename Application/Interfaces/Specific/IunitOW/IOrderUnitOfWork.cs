using Application.Interface;
using Domain.Interfaces.Generic;

namespace Application.Interfaces.Specific.IunitOW
{
    public interface IOrderUnitOfWork : IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        ISaleRepository SaleRepository { get; }
    }
}
