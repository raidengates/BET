using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Services.Interfaces;

namespace Services.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
         where TContext : DbContext
    {
        private readonly TContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private IDbContextTransaction _transaction;
        private Dictionary<string, object> _repositories;
        public TContext Context => _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            if (!_disposed)
                _context.Dispose();
            _disposed = true;

            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
