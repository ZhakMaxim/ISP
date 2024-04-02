using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.BookUseCase.Commands
{
    public class EditBookCommandHandler : IRequestHandler<EditBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            Book existingBook =
                await _unitOfWork.BookRepository.GetByIdAsync(request.SelectedTaskId, cancellationToken);

            existingBook.Title = request.Title;
            existingBook.Rate = request.Rate;

            await _unitOfWork.BookRepository.UpdateAsync(existingBook, cancellationToken);
            await _unitOfWork.SaveAllAsync();

            return existingBook;
        }
    }
}
