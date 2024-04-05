using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.BookUseCase.Commands
{
    public class AddBookToAuthorHandler : IRequestHandler<AddBookToAuthorCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBookToAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(AddBookToAuthorCommand request, CancellationToken cancellationToken)
        {
            Book newBook = new Book(request.Title, request.NameOfImage, request.Id, request.Rate);
            newBook.AddToAuthor(request.AuthorId);
            await _unitOfWork.BookRepository.AddAsync(newBook);
            await _unitOfWork.SaveAllAsync();
            return newBook;
        }
    }
}
