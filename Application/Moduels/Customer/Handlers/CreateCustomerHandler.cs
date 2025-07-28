using Application.Interfaces.Specific.IunitOW;
using Application.Moduels.Customer.Commands;
using AutoMapper;
using Domain.entities;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Application.Moduels.Customer.Handlers
{

    public  class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand,int>
    
    {

        private readonly ILogger<CreateCustomerHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerUnitOfWork _unitOfWork;


        public CreateCustomerHandler(IMapper mapper,
            ICustomerUnitOfWork unitOfWork,
            ILogger<CreateCustomerHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.entities.Person>(request);
            var customer = _mapper.Map<Domain.entities.Customer>(request);

            try
            {
                _logger.LogInformation("Starting create Customer");
                await _unitOfWork.PersonRepository.AddAsync(person);

                customer.Person = person;

                customer.PersonID = person.Id;
                await _unitOfWork.CustomerRepository.AddAsync(customer);

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Customer  created successfully with Id {Id}", customer.Id);

                return customer.Id;
            }
            catch (Exception ex) {
                _logger.LogError(ex,"Erorr ,Customer not Added");
                throw new Exception(ex.Message); }
        }
    }




}

