using BET.Infrastructure;
using BET.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BET.Controllers
{
    [ApiController]
    public abstract class GenericController<T> : ControllerBase where T : class
    {
        protected delegate void DataBaseAction(T model);

        protected readonly IRepositoryBase<T> _repository;

        protected readonly BEDbContext _context;

        public GenericController(IRepositoryBase<T> repository)
        {
            _repository = repository;
            _context = repository.Context;
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var model = _repository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public virtual ActionResult Create(T model)
        {
            if (ModelState.IsValid)
            {
                _repository.WriteIntoDataBase(model, dataBaseAction => _repository.Add(model));
            }
            return Ok(model);
        }

        [HttpGet("DeleteById")]
        public virtual ActionResult Delete(int id)
        {
            var model = _repository.GetById(id);
            return Ok(model);
        }

        [HttpPost("DeleteByModel")]
        public virtual ActionResult Delete(T model)
        {
            _repository.WriteIntoDataBase(model, dataBaseAction => _repository.Delete(model));
            return Ok(model);
        }
        protected abstract ActionResult CreateWithSelectList(int id = 0);
    }
}
