using _253504_Zhak.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Author>> _authorRepository;
        private readonly Lazy<IRepository<Book>> _bookRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _authorRepository = new Lazy<IRepository<Author>>(() =>
            new EfRepository<Author>(context));
           _bookRepository = new Lazy<IRepository<Book>>(() =>
            new EfRepository<Book>(context));
        }
        public IRepository<Author> AuthorRepository
 => _authorRepository.Value;
        public IRepository<Book> BookRepository
         => _bookRepository.Value;
        public async Task CreateDataBaseAsync() =>
         await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>
         await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>
         await _context.SaveChangesAsync();
    }

}

