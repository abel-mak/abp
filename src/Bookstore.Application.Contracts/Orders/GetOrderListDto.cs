using System;
using Volo.Abp.Application.Dtos;

namespace Bookstore.Orders
{
    public class GetOrderListDto : PagedAndSortedResultRequestDto
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
