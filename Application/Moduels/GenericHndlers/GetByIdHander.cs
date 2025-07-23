using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;


namespace Application.Moduels.GenericHndlers
{
    public abstract class GetByIdHander<TQuery, Tdto> : IRequestHandler<TQuery,Tdto>
        where TQuery : IRequest<Tdto>
        
    {
        private readonly IMapper _mapper;
        private readonly  IGenericRepository<IEntity> _repository ;
        protected GetByIdHander(IMapper mapper,IGenericRepository<IEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        protected abstract int GetID(TQuery query);
        public async Task<Tdto> Handle(TQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Entity = await _repository.GetByIDAsync(GetID(request));

                Tdto dto = _mapper.Map<Tdto>(Entity);

                return dto;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
