using Application.Interface;
using Domain.entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;

namespace Infrastructure.Repository.specific_Repo
{
    public class CustomerRepository(AppDbContext context ) : GenericRepository<Customer>(context),ICustomerRepository
    {
      

    }
   
}
