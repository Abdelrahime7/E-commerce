
using Application.Moduels.Item.Commands;
using AutoMapper;
using Application.Interfaces.Specific.IunitOW;
using MediatR;


namespace Application.Moduels.Item.Handlers
{


    public class CreateItemHandler : IRequestHandler<CreateItemCommand, int>
    {


        private readonly IMapper _mapper;
        private readonly IItemUnitOfWork _unitOfWork;


        public CreateItemHandler(IMapper mapper, IItemUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Inventory = _mapper.Map<Domain.entities.Inventory>(request);
                var Item = _mapper.Map<Domain.entities.Item>(request);

                await _unitOfWork.ItemRepository.AddAsync(Item);
                Inventory.Item = Item;
                Inventory.ItemID = Item.Id;
                await _unitOfWork.InventoryRepository.AddAsync(Inventory);

                await _unitOfWork.SaveAsync();
                return Item.Id;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
    }






}
