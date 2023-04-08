using AutoMapper;
using Bookstore.Books;
using Bookstore.Authors;

namespace Bookstore;

public class BookstoreApplicationAutoMapperProfile : Profile
{
    public BookstoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* 
         * You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. 
         */
    }
}
