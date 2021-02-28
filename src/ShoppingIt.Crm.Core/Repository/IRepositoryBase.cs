using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Repository
{
    public interface IRepositoryBase
    {
        Task StartTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackAsync();
    }
}
