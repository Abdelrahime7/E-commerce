using Application.Interfaces.Generic;
using Domain.Interface;
using MediatR;


namespace Application.Moduels.GenericHndlers
{
    public abstract class DeleteHandler<Tcommand> : IRequestHandler<Tcommand, bool>
        where Tcommand : IRequest<bool>
    {

        private readonly IGenericRepository<IEntity> _repository;
        public DeleteHandler( IGenericRepository<IEntity> repository)
        {
      
            _repository = repository;
        }

        abstract protected int GetID(Tcommand command);
       
        public async Task<bool> Handle(Tcommand request, CancellationToken cancellationToken)
        {
            int id = GetID(request);


            if ( await _repository.DeleteAsync(id))
            {
                return true;
            }


            return false;

        }
    }
}
