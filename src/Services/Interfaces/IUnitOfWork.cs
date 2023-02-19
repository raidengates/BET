using Microsoft.EntityFrameworkCore;

namespace Services.Interfaces
{
    public interface IUnitOfWork<out TContext>
        where TContext : DbContext
    {
        TContext Context { get; }
        void CreateTransaction();

        void Commit();

        void Rollback();

        void Save();
    }
}
