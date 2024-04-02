using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Application.AuthorUseCase.Commands
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            Author AuthorToDelete =
                await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id, cancellationToken);
            await _unitOfWork.AuthorRepository.DeleteAsync(AuthorToDelete);

            var AuthorBooks = await _unitOfWork.BookRepository.ListAsync(t => t.AuthorId.Equals(request.Id),
                cancellationToken);
            foreach (var AuthorBook in AuthorBooks)
            {
                await _unitOfWork.BookRepository.DeleteAsync(AuthorBook);
            }

            await _unitOfWork.SaveAllAsync();
            return AuthorToDelete;
        }
    }
}
