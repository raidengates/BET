using BET.Infrastructure;
using BET.Models;
using BET.Services.Interfaces;
using Services.Interfaces;

namespace BET.Services.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork<BEDbContext> unitOfWork) : base(unitOfWork)
        {
            beforeDelete += EmployesCheckExist;
        }

        private void EmployesCheckExist(object sender, TransactionEventArgs args)
        {
            if (sender is Employee employee)
            {
                args.Cancel = (Context.Employees.Where(e => e.Id == e.Id).Any());
            }
        }
    }
}
