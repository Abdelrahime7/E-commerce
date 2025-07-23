
using AutoMapper;


using Application.Moduels.Customer.Commands;
using MediatR;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.Order.Commands;
using Domain.entities;
using Application.Moduels.Inventory.Handlers;

namespace Application.Moduels.Order.Handlers
{


    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IOrderUnitOfWork _unitOfWork;

        public CreateOrderHandler(IMapper mapper, IOrderUnitOfWork unitOfWork )
        {
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

           var Order= _mapper.Map<Domain.entities.Order>(request);
           var Sale= _mapper.Map<Domain.entities.Sale>(request);
           var PurchaseHistory = _mapper.Map<PurchaseHistory>(request);


            try
            {
                await _unitOfWork.OrderRepository.AddAsync(Order);

                Sale.Order = Order;
                Sale.OrderId = Order.Id;
                await _unitOfWork.SaleRepository.AddAsync(Sale);


                PurchaseHistory.Order = Order;
                PurchaseHistory.OrderId = Order.Id;
                PurchaseHistory.Customer = Order.Customer;
                PurchaseHistory.CustomerId = Order.CustomerId;

                await _unitOfWork.PurchaseRepository.AddAsync(PurchaseHistory);

                var Invoices = Order.invoices;
                // iterate List of Invoices for add them One by One ;
                foreach (var invoice in Invoices)
                {
                    var Invoice = _mapper.Map<Domain.entities.Invoice>(invoice);
                    Invoice.Order = Order;
                    Invoice.OrderID = Order.Id;
                    await _unitOfWork.InvoiceRepository.AddAsync(Invoice);
                    // update Inventory :
                    var Inventory = await _unitOfWork.InventoryRepository.GetByIDAsync(Invoice.ItemID);
                    Inventory.ItemQuantity = Invoice.Quantity;
                    await _unitOfWork.InventoryRepository.UpdateAsync(Inventory);

                }
                await _unitOfWork.SaveAsync();
                return Order.Id;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }


        }
    }
}
