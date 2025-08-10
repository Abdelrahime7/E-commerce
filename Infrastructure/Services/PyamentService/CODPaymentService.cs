using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using AutoMapper;
using Domain.Cart;
using Domain.entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Services.PyamentService
{
    public class CODPaymentService : ICODService
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ILogger<CODPaymentService> _logger;

        public CODPaymentService(IOrderService orderService,
            IMapper mapper,
            ILogger<CODPaymentService> logger)
        {
            _logger = logger;
            _mapper = mapper;
             _orderService = orderService;
        }

        public async Task<bool> ConfirmAsync(int ID)
        {
            _logger.LogInformation("ConfirmAsync started for Order ID: {OrderID}", ID);
            OrderDto orderDto = await _orderService.GetOrderByIDAsync(ID);
            Order order = _mapper.Map<Order>(orderDto);
            if (order != null)
            {
                order.Status = OrderStatus.Confirmed;
                _logger.LogInformation("Order ID: {OrderID} confirmed successfully", ID);
                return true;
            }
            _logger.LogWarning("Order ID: {OrderID} not found or mapping failed", ID);
            return false;
        }           


        public async Task InitiateAsync(Cart cart)
        {
            if (cart == null)
            {
                _logger.LogError("InitiateAsync failed: cart is null");
                throw new ArgumentNullException(nameof(cart));
            }

            _logger.LogInformation("InitiateAsync started for Cart ID: {CartID}", cart.Id);

            OrderDto orderDto = _mapper.Map<OrderDto>(cart);
            await _orderService.PlaceOrderAsync(orderDto);

            _logger.LogInformation("Order placed successfully for Cart ID: {CartID}", cart.Id);

        }

        
    }
}
