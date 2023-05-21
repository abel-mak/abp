using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Bookstore.Orders
{
    public class Order : AggregateRoot<Guid>
    {
        public Guid BookId { get; set; }

        public int Quantity { get; set; }

        public Guid UserId { get; set; }

        public DateTime OrderTime { get; set; }

    }
}
