using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Persistense.Repository
{
    public abstract class FakeBookRepository : IRepository<Book>
    {
        List<Book> _list = new List<Book>();
        public FakeBookRepository()
        {
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 10; j++)
                {
                    var trainee = new Book(
                    $"Book {k++}",
                    Random.Shared.NextDouble() * 10);
                    trainee.AddToAuthor(i);
                    _list.Add(trainee);
                }
        }
        public async Task<IReadOnlyList<Book>> ListAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default, 
            params Expression<Func<Book, object>>[]? includesProperties)
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }
        public abstract Task<IReadOnlyList<Book>> ListAllAsync(CancellationToken cancellationToken = default);
        
        public abstract Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default,
           params Expression<Func<Book, object>>[]? includesProperties);
        public abstract Task AddAsync(Book entity, CancellationToken cancellationToken = default);
        public abstract Task UpdateAsync(Book entity, CancellationToken cancellationToken = default);
        public abstract Task DeleteAsync(Book entity, CancellationToken cancellationToken = default);
        public abstract Task<Book> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default);
    }
}
