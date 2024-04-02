using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.BookUseCase.Commands
{
    public class MoveBookToAuthorHandler : IRequestHandler<MoveBookToAuthorCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoveBookToAuthorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(MoveBookToAuthorCommand request, CancellationToken cancellationToken)
        {
            Book existingProjectTask =
             await _unitOfWork.BookRepository.GetByIdAsync(request.SelectedBookId, cancellationToken);
            existingProjectTask.AddToAuthor(request.AuthorId);
            await _unitOfWork.BookRepository.UpdateAsync(existingProjectTask);
            await _unitOfWork.SaveAllAsync();
            return existingProjectTask;
        }
    }
}
