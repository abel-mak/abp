using Bookstore.Authors;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Books
{
    [Authorize]
    public class BookAppService :
        CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>, IBookAppService
    {
        private readonly IAuthorRepository _authorRepository;
        public BookAppService(IRepository<Book, Guid> repository, IAuthorRepository authorRepository) : base(repository)
        {
            _authorRepository = authorRepository;
        }

        public override async Task<BookDto> GetAsync(Guid id)
        {
            IQueryable<Book> bookQueyable = await Repository.GetQueryableAsync();
            IQueryable<Author> authorQueryable = await _authorRepository.GetQueryableAsync();

            IQueryable<dynamic> query = from book in bookQueyable
                                        join author in authorQueryable on book.AuthorId equals author.Id
                                        where book.Id == id
                                        select new { book, author };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult != null)
            {
                return null;
            }

            BookDto res = ObjectMapper.Map<Book, BookDto>(queryResult.book);
            res.AuthorName = queryResult.author.Name;

            return res;
        }

        public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            IQueryable<Book> bookQueryable = await Repository.GetQueryableAsync();
            IQueryable<Author> authorQueryable = await _authorRepository.GetQueryableAsync();

            var query = from book in bookQueryable
                        join author in authorQueryable on book.AuthorId equals author.Id
                        select new { book, author };

            query = query
                //.OrderBy("")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var res = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookDto.AuthorName = x.author.Name;
                return bookDto;
            }).ToList();

            long totalCount = await _authorRepository.GetCountAsync();

            return new PagedResultDto<BookDto>(totalCount, res);
        }

        public void UploadFile()
        {

        }
    }
}
