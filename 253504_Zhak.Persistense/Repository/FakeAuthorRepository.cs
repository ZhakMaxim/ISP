using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Persistense.Repository
{
    public class FakeAuthorRepository : IRepository<Author>
    {
        List<Author> _authors;
        public FakeAuthorRepository() 
        {
            _authors = new List<Author>();
            var author= new Author("Author1", 25, "descriptive");
            author.Id = 1;
            _authors.Add(author);
            author = new Author("Author2", 30, "creative");
            author.Id = 2;

             _authors.Add(author);
        }

        public async Task<IReadOnlyList<Author>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _authors);
        }

        public Task<Author> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Author, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Author>> ListAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default,
            params Expression<Func<Author, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Author> FirstOrDefaultAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
