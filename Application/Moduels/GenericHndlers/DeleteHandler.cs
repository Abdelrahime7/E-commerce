
using MediatR;

namespace Application.Moduels.GenericHndlers
{
    public abstract class DeleteHandler<Tcommand> : IRequestHandler<Tcommand, bool>
        where Tcommand : IRequest<bool>
    {

        public abstract Task<bool> Handle(Tcommand request, CancellationToken cancellationToken);
       
       
    }
}
