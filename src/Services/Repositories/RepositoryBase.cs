using BET.Infrastructure;
using BET.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace BET.Services.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        public BEDbContext Context { get; }

        protected DbSet<T> _table;

        public IUnitOfWork<BEDbContext> UnitOfWork { get; init; }

        public event EventHandler<TransactionEventArgs> beforeSave;

        public event EventHandler<TransactionEventArgs> onSave;

        public event EventHandler<TransactionEventArgs> beforeDelete;

        public event EventHandler<TransactionEventArgs> completeUow;

        private string _errorMessage = string.Empty;

        private bool _isDisposed;

        public RepositoryBase(IUnitOfWork<BEDbContext> unitOfWork) : this(unitOfWork.Context)
        {
            UnitOfWork = unitOfWork;
        }

        public RepositoryBase(BEDbContext context)
        {
            _isDisposed = false;
            Context = context;
        }

        protected virtual DbSet<T> Table
        {
            get { return _table ?? (_table = Context.Set<T>()); }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            Table.Add(item);
        }

        public void Delete(T item)
        {
            var args = new TransactionEventArgs();
            beforeDelete?.Invoke(item, args);

            if (args.Cancel)
                throw new Exception("Item cannot be deleted!");
            else
            {
                if (item == null)
                    throw new ArgumentNullException("entity");
                Table.Remove(item);

            }
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }

        public void Edit(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            SetEntryModified(item);
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public virtual List<T> GetList()
        {
            return Table.ToList();
        }

        public virtual void SetEntryModified(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public void WriteIntoDataBase(T item, IRepositoryBase<T>.DataBaseAction dataBaseAction)
        {
            if (dataBaseAction == null)
                return;

            try
            {
                UnitOfWork.CreateTransaction();
                dataBaseAction(item);
                UnitOfWork.Save();
                if (completeUow != null)
                {
                    var args = new TransactionEventArgs();
                    completeUow?.Invoke(item, args);
                    UnitOfWork.Save();
                }
                UnitOfWork.Commit();
            }
            catch
            {
                UnitOfWork.Rollback();
            }
        }
    }
}
