using BET.Infrastructure;
using BET.Models;
using BET.Services.Interfaces;
using Services.Interfaces;

namespace BET.Services.Repositories
{
    public class DeparmentEmployeeRepository : RepositoryBase<DeparmentEmployee>, IDeparmentEmployeeRepository
    {
        public DeparmentEmployeeRepository(IUnitOfWork<BEDbContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
