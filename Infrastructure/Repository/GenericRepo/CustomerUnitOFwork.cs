
using Infrastructure.ADbContext;
using Application.Interface;
using Application.Interfaces.Specific.IunitOW;

namespace Infrastructure.Repository.GenericRepo
{
    public class CustomerUnitOFwork(ICustomerRepository customerRepository, IPersonRepository personRepository, AppDbContext appDbContext) : ICustomerUnitOfWork
    {
        
        private readonly AppDbContext _appDbContext = appDbContext;

        ICustomerRepository ICustomerUnitOfWork.CustomerRepository => customerRepository;

        IPersonRepository ICustomerUnitOfWork.PersonRepository => personRepository;


        public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();
        
        public void Dispose()=>_appDbContext.Dispose();

        
    }
}
