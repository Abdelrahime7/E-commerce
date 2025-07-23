using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;

namespace Application.Moduels.GenericHndlers
{
    public class GetAllHandler<Tquery, Tdto> : IRequestHandler<Tquery, IReadOnlyCollection<Tdto>>
        where Tquery : IRequest<IReadOnlyCollection<Tdto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IEntity> _repository;
        public GetAllHandler(IMapper mapper, IGenericRepository<IEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

       

        public async Task<IReadOnlyCollection<Tdto>> Handle(Tquery request, CancellationToken cancellationToken)

        {
            try
            {
                var entities = await _repository.GetAllAsync();

                return _mapper.Map<IReadOnlyCollection<Tdto>>(entities);
            }catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
