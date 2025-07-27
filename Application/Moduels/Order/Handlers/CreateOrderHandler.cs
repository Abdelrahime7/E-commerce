
using AutoMapper;


using Application.Moduels.Customer.Commands;
using MediatR;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.Order.Commands;
using Domain.entities;
using Application.Moduels.Inventory.Handlers;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.Order.Handlers
{


    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly ILogger<CreateOrderHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderUnitOfWork _unitOfWork;

        public CreateOrderHandler(IMapper mapper, IOrderUnitOfWork unitOfWork,
            ILogger<CreateOrderHandler> logger)
        {
            _logger= logger;
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var Order = _mapper.Map<Domain.entities.Order>(request);
            var Sale = _mapper.Map<Domain.entities.Sale>(request);
            var PurchaseHistory = _mapper.Map<PurchaseHistory>(request);
         

            try
            {
                await _unitOfWork.OrderRepository.AddAsync(Order);
                _logger.LogInformation("Order added: {@Order}", Order);

                Sale.Order = Order;
                Sale.OrderId = Order.Id;
                await _unitOfWork.SaleRepository.AddAsync(Sale);
                _logger.LogInformation("Sale added: {@Sale}", Sale);

                PurchaseHistory.Order = Order;
                PurchaseHistory.OrderId = Order.Id;
                PurchaseHistory.Customer = Order.Customer;
                PurchaseHistory.CustomerId = Order.CustomerId;
                await _unitOfWork.PurchaseRepository.AddAsync(PurchaseHistory);
                _logger.LogInformation("PurchaseHistory added: {@PurchaseHistory}", PurchaseHistory);

                var Invoices = Order.invoices;
                _logger.LogInformation("Processing {Count} invoices", Invoices.Count);

                foreach (var invoice in Invoices)
                {
                    var Invoice = _mapper.Map<Domain.entities.Invoice>(invoice);
                    Invoice.Order = Order;
                    Invoice.OrderID = Order.Id;
                    await _unitOfWork.InvoiceRepository.AddAsync(Invoice);
                    _logger.LogInformation("Invoice added: {@Invoice}", Invoice);

                    var Inventory = await _unitOfWork.InventoryRepository.GetByIDAsync(Invoice.ItemID);
                    Inventory.ItemQuantity = Invoice.Quantity;
                    await _unitOfWork.InventoryRepository.UpdateAsync(Inventory);
                    _logger.LogInformation("Inventory updated for ItemID {ItemID}: {@Inventory}", Invoice.ItemID, Inventory);
                }

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Order with {OderID} saved successfully",Order.Id);

                return Order.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing order");
                throw new Exception(ex.Message);
            }



        }
    }
}
