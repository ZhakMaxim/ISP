using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.BookUseCase.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.BookRepository.GetByIdAsync(request.SelectedTaskId);
            await _unitOfWork.BookRepository.DeleteAsync(task, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return task;
        }
    }
}
