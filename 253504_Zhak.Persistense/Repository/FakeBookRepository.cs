using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Persistense.Repository
{
    public class FakeBookRepository : IRepository<Book>
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
                    "dotnet_bot.png",
                    ++j,
                    Random.Shared.NextDouble() * 10
                    );
                    trainee.AddToAuthor(i);
                    _list.Add(trainee);
                }
        }
        public Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Book, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Book>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _list);
        }

        public Task<IReadOnlyList<Book>> ListAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default,
            params Expression<Func<Book, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Book> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
