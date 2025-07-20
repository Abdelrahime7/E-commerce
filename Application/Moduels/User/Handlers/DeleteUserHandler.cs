using Application.Moduels.User.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Specific.IunitOW;

namespace Application.Moduels.User.Handlers
{
    public class DeleteUserHandler(IUserUnitOfWork unitOfWork) : DeleteHandler<DeleteUserCommand>
    {
        private readonly IUserUnitOfWork _unitOfWork = unitOfWork;

        public override async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIDAsync(request.ID);
            if (user == null) 
                return false;
            await _unitOfWork.PersonRepository.DeleteAsync(user.PersonID);
            await _unitOfWork.UserRepository.DeleteAsync(user.Id);
            await _unitOfWork.SaveAsync();

            return true;

        }

      





    }





}

