using Bookstore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Authors
{
    public class EfCoreAuthorRepository : 
        EfCoreRepository<BookstoreDbContext, Author, Guid>,
        IAuthorRepository
    {

        public EfCoreAuthorRepository(IDbContextProvider<BookstoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Author> FindByNameAsync(string name)
        {
            Check.NotNullOrEmpty(name, nameof(name));

            DbSet<Author> dbSet = await GetDbSetAsync();
            return dbSet.FirstOrDefault(x => x.Name == name);
        }

        public async Task<List<Author>> GetListAsync(
            int skipCount,
            int maxResultPage,
            string sorting,
            string filter = null)
        {
            DbSet<Author> dbSet = await GetDbSetAsync();

            return dbSet
                .WhereIf(!filter.IsNullOrEmpty(), author => author.Name.Contains(filter))
                .OrderBy(author => author.Name)
                .Skip(skipCount)
                .Take(maxResultPage)
                .ToList();
        }

        public async Task<List<Author>> SearchAsync(string search)
        {
            DbSet<Author> dbset = await GetDbSetAsync();

            return dbset.Where(author => author.Name.Contains(search)).ToList();

        }
    }
}
