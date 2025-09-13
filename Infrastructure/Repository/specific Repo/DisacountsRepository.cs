using Application.Interfaces.Specific;
using Domain.Entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;

namespace Infrastructure.Repository.specific_Repo
{
    public class DisacountsRepository(AppDbContext context):GenericRepository<Disacount>(context),IDisacountsRepository
    {
    }
}
