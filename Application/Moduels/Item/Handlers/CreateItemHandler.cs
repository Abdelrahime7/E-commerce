
using Application.Moduels.Item.Commands;
using AutoMapper;
using Application.Interfaces.Specific.IunitOW;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.Item.Handlers
{


    public class CreateItemHandler : IRequestHandler<CreateItemCommand, int>
    {

        private readonly ILogger<CreateItemHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IItemUnitOfWork _unitOfWork;


        public CreateItemHandler(IMapper mapper, IItemUnitOfWork unitOfWork,
            ILogger<CreateItemHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Starting inventory creation for product {ProductName}", request.itemDto.Name);

                var inventory = _mapper.Map<Domain.entities.Inventory>(request);
                var item = _mapper.Map<Domain.entities.Item>(request);

                await _unitOfWork.ItemRepository.AddAsync(item);

                inventory.Item = item;
                inventory.ItemID = item.Id;

                await _unitOfWork.InventoryRepository.AddAsync(inventory);
                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Inventory and item created successfully with ItemId {ItemId}", item.Id);

                return item.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create inventory for product {ProductName}", request.itemDto.Name);
                throw; 
            }

            
        }
    }






}
