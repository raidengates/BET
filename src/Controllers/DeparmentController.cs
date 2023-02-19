using BET.Models;
using BET.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BET.Controllers
{
    [Route("[controller]")]
    public class DeparmentController : GenericController<Deparment>
    {
        public DeparmentController(IDeparmentRepository repository) : base(repository)
        {
        }

        protected override ActionResult CreateWithSelectList(int id = 0)
        {
            throw new NotImplementedException();
        }
    }
}
