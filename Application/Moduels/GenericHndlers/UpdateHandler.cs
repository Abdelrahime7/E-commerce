
using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;


namespace Application.Moduels.GenericHndlers
{

     
   public abstract class UpdateHandler<TComande,Tdto>  : IRequestHandler<TComande,Tdto> 
        where TComande : IRequest<Tdto>
    

       
    {
       
       
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IEntity> _repository;


        public UpdateHandler( IMapper mapper, IGenericRepository<IEntity> repository)
        {
           
            _mapper = mapper;
            _repository = repository;
        }
        protected abstract int GetId(TComande command);

        public async Task<Tdto> Handle(TComande request, CancellationToken cancellationToken)
        {

            var Entity =  await _repository.GetByIDAsync(GetId(request));
            if (Entity is null)
            {
                throw new Exception($"{typeof(IEntity).Name} not found.");
            }

            _mapper.Map(request, Entity);

            await _repository.UpdateAsync(Entity);

             return  _mapper.Map<Tdto>(Entity); 


        }

      
    }
}
