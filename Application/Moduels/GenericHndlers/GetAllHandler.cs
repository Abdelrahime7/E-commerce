using Application.Interfaces.Generic;
using AutoMapper;
using Domain.Interface;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.GenericHndlers
{
    public class GetAllHandler<Tquery, Tdto> : IRequestHandler<Tquery, IReadOnlyCollection<Tdto>>
        where Tquery : IRequest<IReadOnlyCollection<Tdto>>
    {
        private readonly ILogger<GetAllHandler<Tquery, Tdto>> _logger;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IEntity> _repository;

        public GetAllHandler(IMapper mapper,
            IGenericRepository<IEntity> repository,
            ILogger<GetAllHandler<Tquery, Tdto>> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

       

        public async Task<IReadOnlyCollection<Tdto>> Handle(Tquery request, CancellationToken cancellationToken)

        {
            try
            {
                var entities = await _repository.GetAllAsync();

                return _mapper.Map<IReadOnlyCollection<Tdto>>(entities);
            }catch (Exception ex) {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message); }
        }
    }
}
