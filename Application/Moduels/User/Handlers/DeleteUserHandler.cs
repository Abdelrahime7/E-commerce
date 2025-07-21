using Application.Moduels.User.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Specific.IunitOW;

namespace Application.Moduels.User.Handlers
{
    public class DeleteUserHandler(IUserUnitOfWork unitOfWork) : DeleteHandler<SoftDeleteUserCommand>
    {
        private readonly IUserUnitOfWork _unitOfWork = unitOfWork;

        public override async Task<bool> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIDAsync(request.ID);
            if (user == null) 
                return false;
            await _unitOfWork.PersonRepository.SoftDeleteAsync(user.PersonID);
            await _unitOfWork.UserRepository.SoftDeleteAsync(user.Id);

            return await _unitOfWork.SaveAsync() >0;

            

        }

      





    }





}

