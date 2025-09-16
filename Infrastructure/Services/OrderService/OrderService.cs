using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using Application.Moduels.Order.Commands;
using  MediatR;
using static Application.Moduels.Order.Queries.Queries;


namespace Infrastructure.Services.OrderService
{
     
    public class OrderService : IOrderService
    {
        
        private readonly IMediator _mediator;
        

        public OrderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
            => await _mediator.Send(new GetAllOrdersQuery());
       

        public async Task<OrderDto> GetOrderByIDAsync(int ID)
            =>await _mediator.Send( new GetOrderByIdQuery(ID));

        public async Task<int> PlaceOrderAsync(OrderDto dto)   
          => await _mediator.Send( new CreateOrderCommand(dto));
            
        public async Task<bool> SoftDeleteOrderAsync(int ID)
            => await _mediator.Send( new SoftDeleteOrderCommand(ID));
     

        public async Task<OrderDto> UpdateOrderAsync(OrderRequest response)
           => await _mediator.Send(new UpdateOrderCommand(response));

           
        
    }
}
