using Microsoft.EntityFrameworkCore.Storage;
using MOMO.Infrastructure.UnitOfWork;
using System;

namespace MOMO.Infrastructure.UnitOfWork.EntityFramework
{
    internal class EntityFrameworkTransaction : ITransaction
    {
        private IDbContextTransaction Transaction { get; set; }

        public EntityFrameworkTransaction(IDbContextTransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentException("transaction");
            }

            this.Transaction = transaction;
        }

        public void Commit()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Dispose();
            }
        }
    }
}
