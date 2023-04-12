using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Bookstore.Books
{
    public class CreateUpdateBookDto
    {
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set;}

        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime publishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
    }
}
