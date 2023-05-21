using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bookstore.Orders
{
    public class OrderDto : EntityDto<Guid>
    {
        public string UserName { get; set; }

        public Guid BookId { get; set; }

        public int Quantity { get; set; }

        public Guid UserId { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
