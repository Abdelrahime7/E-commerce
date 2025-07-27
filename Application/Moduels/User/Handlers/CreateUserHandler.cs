using AutoMapper;
using Application.Moduels.User.Commands;
using MediatR;
using Application.Interfaces.Specific.IunitOW;
using Microsoft.Extensions.Logging;


namespace Application.Moduels.User.Handlers
{

  

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {

        private readonly ILogger<CreateUserHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserUnitOfWork _unitOfWork;


        public CreateUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork, ILogger<CreateUserHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           
            var person = _mapper.Map<Domain.entities.Person>(request);
            var User = _mapper.Map<Domain.entities.User>(request);
            try
            {
                _logger.LogInformation("Starting Add user procces ");
                await _unitOfWork.PersonRepository.AddAsync(person);

                _logger.LogInformation(" Add Person with id :{id} ",person.Id);
                User.Person = person;
                User.PersonID = person.Id;
                await _unitOfWork.UserRepository.AddAsync(User);
                _logger.LogInformation(" Add User with id :{id} ", User.Id);

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("  User with id :{id} Added Successfully  ", User.Id);
                return User.Id;
            }
            catch (Exception ex) {
                _logger.LogInformation(ex," Erorr !! Usernot added ");
                throw new Exception(ex.Message); }

        }
    }



}
