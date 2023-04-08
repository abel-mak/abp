using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bookstore.Books
{
    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Title { get; set; }

        public DateTime publishDate { get; set; }

        public float Price { get; set; }
    }
}
