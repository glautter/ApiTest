using Hex.Application.Repositories;
using Hex.Infra.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Hex.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly HexContext Context;
        private bool completed = false;
        private readonly IDbContextTransaction transaction;

        public UnitOfWork(HexContext context)
        {
            this.Context = context;

            if (context.Database.CurrentTransaction == null)
                transaction = context.Database.BeginTransaction();
            else
                transaction = context.Database.CurrentTransaction;
        }

        public void Complete()
        {
            if (completed)
                throw new UnitOfWorkAlreadyCompletedException();

            if (transaction != null)
                transaction.Commit();

            completed = true;
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                if (!completed)
                    Context.Database.RollbackTransaction();

                transaction.Dispose();
            }
        }
    }
}
