using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bookstore.Orders
{
    public class CreateUpdateOrderDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
