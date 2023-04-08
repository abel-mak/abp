using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace Bookstore.Authors
{
    public interface IAuthorAppService : IApplicationService
    {
        Task<AuthorDto> GetAsync(Guid id);

        Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input);

        Task<AuthorDto> CreateAsync(CreateAuthorDto input);


        Task UpdateAsync(Guid id, UpdateAuthorDto input);

        Task DeleteAsync(Guid id);
    }
}
