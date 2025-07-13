
using Application.Moduels.Item.Commands;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Application.Interfaces.Generic;
using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.User.Commands;
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
            var Inventory = _mapper.Map<Domain.entities.Inventory>(request);
            var Item = _mapper.Map<Domain.entities.Item>(request);

            await _unitOfWork.ItemRepository.AddAsync(Item);
            Inventory.Item = Item;
            Inventory.ItemID = Item.Id;
            await _unitOfWork.InventoryRepository.AddAsync(Inventory);

            await _unitOfWork.SaveAsync();
            return Item.Id;


        }
    }






}
