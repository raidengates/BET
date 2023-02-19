using BET.Infrastructure;
using BET.Services.Repositories;
using Services.Interfaces;

namespace BET.Services.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        BEDbContext Context { get; }
        IUnitOfWork<BEDbContext> UnitOfWork { get; }

        delegate void DataBaseAction(T item);

        event EventHandler<TransactionEventArgs> completeUow;

        List<T> GetList();

        T GetById(int id);

        void Add(T item);

        void Edit(T item);

        void Delete(T item);

        void WriteIntoDataBase(T item, DataBaseAction dataBaseAction);
    }
}
