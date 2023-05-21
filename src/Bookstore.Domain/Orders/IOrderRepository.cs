﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Bookstore.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}
