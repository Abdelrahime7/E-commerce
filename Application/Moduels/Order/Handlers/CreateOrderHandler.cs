
using AutoMapper;


using MediatR;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.Order.Commands;
using Domain.entities;
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
                _logger.LogInformation("Starting Order creation for {order}", request.OrderDto);

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

                foreach (var invoice in Invoices)
                {
                    var Invoice = _mapper.Map<Domain.entities.Invoice>(invoice);
                    Invoice.Order = Order;
                    Invoice.OrderID = Order.Id;
                    await _unitOfWork.InvoiceRepository.AddAsync(Invoice);
                    _logger.LogInformation("Invoice added: {@Invoice}", Invoice);
                   
                }

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Order   created successfully with Id {Id}", Order.Id);

                return Order.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Order  {Order}", request.OrderDto);
                throw new Exception(ex.Message);
            }



        }
    }
}
