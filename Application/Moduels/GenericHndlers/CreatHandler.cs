using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;


namespace Application.Moduels.GenericHndlers
{

     
   public abstract class CreatHandler <TComande>  : IRequestHandler<TComande, int> 
        where TComande : IRequest<int>
       
    {
       
        
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IEntity> _repository;


        public CreatHandler( IMapper mapper, IGenericRepository<IEntity> repository)
        {
           
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(TComande request, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<IEntity>(request);
            await _repository.AddAsync(Entity);
            return Entity.Id;
        }
    }
}
