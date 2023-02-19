using BET.Infrastructure;
using BET.Models;
using BET.Services.Interfaces;
using Services.Interfaces;

namespace BET.Services.Repositories
{
    public class DeparmentRepository : RepositoryBase<Deparment>, IDeparmentRepository
    {
        public DeparmentRepository(IUnitOfWork<BEDbContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
