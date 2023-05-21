using AutoMapper;
using Bookstore.Books;
using Bookstore.Authors;
using Bookstore.Orders;

namespace Bookstore;

public class BookstoreApplicationAutoMapperProfile : Profile
{
    public BookstoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Author, AuthorDto>();

        CreateMap<CreateUpdateOrderDto, Order>();
        CreateMap<Order,  OrderDto>();

        /* 
         * You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. 
         */
    }
}
