using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.GenericHndlers
{

     
   public abstract class CreatHandler <TComande>  : IRequestHandler<TComande, int> 
        where TComande : IRequest<int>
       
    {

        private readonly ILogger<CreatHandler<TComande>> _logger;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IEntity> _repository;


        public CreatHandler( IMapper mapper,
            IGenericRepository<IEntity> repository,
              ILogger<CreatHandler<TComande>> logger
            )
        {
           _logger= logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(TComande request, CancellationToken cancellationToken)
        {
            try
            {
               var Entity = _mapper.Map<IEntity>(request);
                await _repository.AddAsync(Entity);
                _logger.LogInformation("Create {Entity} with id :{ID}", typeof(IEntity).Name,Entity.Id);

                return Entity.Id;
            }
            catch (Exception ex) {
                _logger.LogError(ex,"Failed to add {Entity}",typeof(IEntity).Name);
                throw new Exception(ex.Message); }
                
        }
    }
}
