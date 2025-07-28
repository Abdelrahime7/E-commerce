
using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.GenericHndlers
{

     
   public abstract class UpdateHandler<TComande,Tdto>  : IRequestHandler<TComande,Tdto> 
        where TComande : IRequest<Tdto>
    

       
    {

        private readonly ILogger<UpdateHandler<TComande, Tdto>> _logger;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IEntity> _repository;


        public UpdateHandler( IMapper mapper, 
            IGenericRepository<IEntity> repository,
            ILogger<UpdateHandler<TComande, Tdto>> logger
            )
        {
           _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }
        protected abstract int GetId(TComande command);

        public async Task<Tdto> Handle(TComande request, CancellationToken cancellationToken)
        {
            try
            {
                var Entity = await _repository.GetByIDAsync(GetId(request));
                if (Entity is null)
                {
                    _logger.LogWarning("{EntityType} with ID {EntityId} not found.", typeof(IEntity).Name, GetId(request));
                    throw new   NullReferenceException($"{typeof(IEntity).Name} not found.");
                }

                _mapper.Map(request, Entity);

                await _repository.UpdateAsync(Entity);

                return _mapper.Map<Tdto>(Entity);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message); }
        }

      
    }
}
