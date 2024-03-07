using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Persistense.Repository
{
    public abstract class FakeAuthorRepository : IRepository<Author>
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

        public abstract Task<Author> GetByIdAsync(int id, CancellationToken cancellationToken = default,
           params Expression<Func<Author, object>>[]? includesProperties);
        public abstract Task<IReadOnlyList<Author>> ListAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default,
            params Expression<Func<Author, object>>[]? includesProperties);
        public abstract Task AddAsync(Author entity, CancellationToken cancellationToken = default);
        public abstract Task UpdateAsync(Author entity, CancellationToken cancellationToken = default);
        public abstract Task DeleteAsync(Author entity, CancellationToken cancellationToken = default);
        public abstract Task<Author> FirstOrDefaultAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default);
    }
}
