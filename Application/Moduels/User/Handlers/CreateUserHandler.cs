using AutoMapper;
using Application.Moduels.User.Commands;
using MediatR;
using Application.Interfaces.Specific.IunitOW;


namespace Application.Moduels.User.Handlers
{

  

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
    

        private readonly IMapper _mapper;
        private readonly IUserUnitOfWork _unitOfWork;


        public CreateUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.entities.Person>(request);
            var User = _mapper.Map<Domain.entities.User>(request);

            await _unitOfWork.PersonRepository.AddAsync(person);
            User.Person = person;
            User.PersonID = person.Id;
            await _unitOfWork.UserRepository.AddAsync(User);

            await _unitOfWork.SaveAsync();
            return User.Id;


        }
    }



}
