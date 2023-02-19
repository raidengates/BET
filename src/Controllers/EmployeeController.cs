using BET.Models;
using BET.Services.Interfaces;
using BET.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BET.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : GenericController<Employee>
    {
        public EmployeeController(IEmployeeRepository repository) : base(repository)
        {
            repository.completeUow += Repository_completeUow;
        }

        private void Repository_completeUow(object? sender, TransactionEventArgs args)
        {
            if (sender is Employee employee)
            {
                employee.Code = $"EMP-{employee.Id}";
            }
        }

        protected override ActionResult CreateWithSelectList(int id = 0)
        {
            throw new NotImplementedException();
        }
    }
}
