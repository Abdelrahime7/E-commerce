using Application.Moduels.User.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Specific.IunitOW;
using Microsoft.Extensions.Logging;

namespace Application.Moduels.User.Handlers
{
    public class DeleteUserHandler(IUserUnitOfWork unitOfWork,
      ILogger<DeleteUserHandler> logger) : DeleteHandler<SoftDeleteUserCommand>
    {
        private readonly ILogger<DeleteUserHandler> _logger = logger;
        private readonly IUserUnitOfWork _unitOfWork = unitOfWork;

        public override async Task<bool> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIDAsync(request.ID);
                _logger.LogInformation("try to get User with id :{id}", request.ID);
                if (user == null)
                {
                    _logger.LogWarning(" User with id :{id} not found" , request.ID);
                    return false;
                }
                await _unitOfWork.PersonRepository.SoftDeleteAsync(user.PersonID);
                await _unitOfWork.UserRepository.SoftDeleteAsync(user.Id);

                var result= await _unitOfWork.SaveAsync() > 0;
                _logger.LogInformation(" User with id :{id} Deleted", request.ID);
                return  result; 
            }
            catch (Exception ex) {
                _logger.LogInformation(ex ,"Erorr  user not Deleted");
                throw new Exception(ex.Message); }

               

        }

      





    }





}

