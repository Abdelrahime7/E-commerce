using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.GenericHndlers
{
    public abstract class GetByIdHander<TQuery, Tdto> : IRequestHandler<TQuery,Tdto>
        where TQuery : IRequest<Tdto>
        

    {

        private readonly ILogger<GetByIdHander<TQuery, Tdto>> _logger;
        private readonly IMapper _mapper;
        private readonly  IGenericRepository<IEntity> _repository ;
        protected GetByIdHander(IMapper mapper,
            IGenericRepository<IEntity> repository,
            ILogger<GetByIdHander<TQuery, Tdto>> logger
            )
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        protected abstract int GetID(TQuery query);
        public async Task<Tdto> Handle(TQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Entity = await _repository.GetByIDAsync(GetID(request));
                if (Entity == null)
                {
                    _logger.LogWarning("{EntityType} with ID {EntityId} not found.", typeof(IEntity).Name, GetID(request));
                    throw new NullReferenceException(typeof(IEntity).Name + "Is Null");
                }

                Tdto dto = _mapper.Map<Tdto>(Entity);

                return dto;
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                throw; }
        }
    }
}
