using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Bookstore.Authors
{
    public class AuthorAppService : BookstoreAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            Author author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = nameof(Author.Name);
            }
            List<Author> list = await _authorRepository
                .GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);
            long totalCount = input.Filter.IsNullOrEmpty()
                ? await _authorRepository.CountAsync() :
                await _authorRepository.CountAsync(x => x.Name.Contains(input.Filter));
            return new PagedResultDto<AuthorDto>(totalCount, ObjectMapper.Map<List<Author>, List<AuthorDto>>(list));
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            Author author = await _authorManager.CreateAsync(input.Name, input.BirthDate, input.ShortBio);

            await _authorRepository.InsertAsync(author);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            Author author = await _authorRepository.GetAsync(id);

            await _authorManager.ChangeNameAsync(author, input.Name);
            author.BirthDate = input.BirthDate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<AuthorDto>> SearchAsync(string search)
        {
            List<Author> res = await _authorRepository.SearchAsync(search);

            return ObjectMapper.Map<List<Author>, List<AuthorDto>>(res);
        }
    }
}