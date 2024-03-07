using _253504_Zhak.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
