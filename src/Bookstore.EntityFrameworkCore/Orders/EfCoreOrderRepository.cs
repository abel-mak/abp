using Bookstore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bookstore.Orders
{
    public class EfCoreOrderRepository : EfCoreRepository<BookstoreDbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(IDbContextProvider<BookstoreDbContext> dbContextProvider)
            : base(dbContextProvider) 
        {
        }
    }
}
