using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Bookstore.Authors
{
    public class AuthorManager : DomainService
    {
        public readonly IAuthorRepository _authorrepository;

        public AuthorManager(IAuthorRepository authorrepository)
        {
            _authorrepository = authorrepository;
        }

        public async Task<Author> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            var existingAuthor = await _authorrepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new AuthorAlreadyExistsException(name);
            }
            return new Author(GuidGenerator.Create(), name, birthDate, shortBio);
        }

        public async Task ChangeNameAsync(Author author, string newname) 
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newname, nameof(newname));

            Author existingAuthor = await _authorrepository.FindByNameAsync(newname);

            if (existingAuthor == null)
            {
                author.Name = newname;
                return;
            }
            throw new AuthorAlreadyExistsException(newname);
        }
    }
}
