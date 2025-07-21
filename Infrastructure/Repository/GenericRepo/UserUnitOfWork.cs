using Application.Interface;
using Application.Interfaces.Specific.IunitOW;
using Infrastructure.ADbContext;
using Infrastructure.Repository.specific_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.GenericRepo
{
    internal class UserUnitOfWork(IUserRepository userRepository, IPersonRepository personRepository, AppDbContext appDbContext) : IUserUnitOfWork
    {

        private readonly AppDbContext _appDbContext = appDbContext;
        public IUserRepository UserRepository => userRepository;

        public IPersonRepository PersonRepository => personRepository;


        public void Dispose()=>_appDbContext.Dispose();


        public async Task<int> SaveAsync() => await _appDbContext.SaveChangesAsync();


    }
}
